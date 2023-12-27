namespace MicroservicesWithCQRSDesignPattern.Quries.QueryModel
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
