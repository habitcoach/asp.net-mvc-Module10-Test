using Module10Test.Models;

namespace Module10Test.Services
{
    public class FakeProductRepo : IProductRepo
    {
        public List<Product> Products { get; set; }

        public Product Add(Product product)
        {
            Products.Add(product);
            return product;
        }
    }
}
