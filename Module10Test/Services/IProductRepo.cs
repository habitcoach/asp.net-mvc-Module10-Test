using Module10Test.Models;

namespace Module10Test.Services
{
    public interface IProductRepo
    {
        List<Product> Products { get; }
        Product Add(Product product);

    }
}
