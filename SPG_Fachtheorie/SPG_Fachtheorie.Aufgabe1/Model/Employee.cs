namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
