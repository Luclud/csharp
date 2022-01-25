using Xunit;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe1.Test;

/// <summary>
/// Unittests für den DBContext.
/// Die Datenbank wird im Ordner SPG_Fachtheorie\SPG_Fachtheorie.Aufgabe1.Test\bin\Debug\net6.0\Invoice.db
/// erzeugt und kann mit SQLite Management Studio oder DBeaver betrachtet werden
/// </summary>
public class InvoiceContextTests
{
    /// <summary>
    /// Prüft, ob die Datenbank mit dem Model im InvoiceContext angelegt werden kann.
    /// </summary>
    [Fact]
    public void CreateDatabaseTest()
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=Invoice.db")
            .Options;

        using var db = new InvoiceContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        Employee employee = new Employee()
        {
            Vorname = "Lukas",
            Nachname = "Eifrig"
        };
        db.Employees.Add(employee);

        Company company = new Company()
        {
            Name = "Musterfirma GmbH",
            Anschrift = "Straße 1",
            Email = "office@musterfirma.at",
            Telefonnummer = "(01) 123 45 67"
        };
        db.Companys.Add(company);

        Article article1 = new Article()
        {
            Name = "Samsung Galaxy A52s",
            Preis = 393.90f
        };
        Article article2 = new Article()
        {
            Name = "Samsung Galaxy Tab A7",
            Preis = 178f
        };
        Article article3 = new Article()
        {
            Name = "SanDisk Extreme, microSD",
            Preis = 70.49f
        };
        db.Articles.AddRange(article1, article2, article3);

        Customer customer = new Customer()
        {
            Vorname = "Stefanie",
            Nachname = "Musterkundin"
        };
        db.Customers.Add(customer);

        Invoice invoice = new Invoice()
        {
            Nummer = 0001,
            Customer = customer,
            Clerk = employee,
            Rabatt = 3,
            Datum = System.DateTime.Now
        };
        db.Invoices.Add(invoice);

        List<InvoiceItem> invoiceItems = new List<InvoiceItem>()
        {
            new InvoiceItem()
            {
                Article = article1,
                Anzahl = 1,
                ArticlePreis = article1.Preis,
                Invoice = invoice
            },
            new InvoiceItem(){
                Article = article2,
                Anzahl = 1,
                ArticlePreis = article2.Preis,
                Invoice = invoice
            },
            new InvoiceItem()
            {
                Article = article3,
                Anzahl = 2,
                ArticlePreis = article3.Preis,
                Invoice = invoice
            }
        };
        db.InvoiceItems.AddRange(invoiceItems);
        db.SaveChanges();
    }
}