namespace CodeCamp.NewFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string? Upc { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }

        public Product(string name, string category) => (Name, Category) = (name, category);
    }
}