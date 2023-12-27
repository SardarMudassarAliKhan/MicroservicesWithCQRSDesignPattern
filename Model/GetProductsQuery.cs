namespace MicroservicesWithCQRSDesignPattern.Model
{
    public class GetProductsQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public string SearchTerm { get; set; } 
        public decimal? MinPrice { get; set; } 
        public decimal? MaxPrice { get; set; } 
    }
}
