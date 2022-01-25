namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Article
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Nummer { get; set; }
        public float Preis { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
