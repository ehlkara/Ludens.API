namespace Ludens.Models.Entities.Ludens
{
    public class Funds
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<FundPrices> FundPrices { get; set; }
    }
}
