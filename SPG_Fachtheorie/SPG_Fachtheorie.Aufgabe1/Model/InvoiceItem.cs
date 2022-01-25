namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
        public int Anzahl { get; set; }
        public float ArticlePreis { get; set; }
    }
}
