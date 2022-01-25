using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public enum Anrede { Mr, Ms }
    public class Customer
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Anschrift { get; set; }
        public Anrede Anrede { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
