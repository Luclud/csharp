using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public Employee Clerk { get; set; }
        public Guid ClerkId { get; set; }
        public int Rabatt { get; set; }
        public DateTime Datum { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Nummer { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
