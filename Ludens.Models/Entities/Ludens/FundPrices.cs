namespace Ludens.Models.Entities.Ludens
{
    public class FundPrices
    {
        public string Id { get; set; }
        public string FundId { get; set; }
        public Funds Funds { get; set; }
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }
}
