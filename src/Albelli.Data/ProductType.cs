namespace Albelli.Data
{
    public class ProductType : IEntity
    {
        public int Id { get; set; }
        public ProductTypes Type => (ProductTypes)Id;
        public decimal PackageWidth { get; set; }
        public int ItemsInPackage { get; set; }
    }
}
