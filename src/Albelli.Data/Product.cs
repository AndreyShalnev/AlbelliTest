namespace Albelli.Data
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
    }
}
