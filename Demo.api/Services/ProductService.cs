
namespace Demo.api.Services;

public class ProductService : IProductService
{
    private static readonly List<Product> _products = [
           new Product
           {
               Id = 1, 
               Name = "Oppo 5g",
               Price = 15000
           },
           new Product
           {
               Id = 2,
               Name = "Oppo reno 15",
               Price = 25000
           },
           new Product
           {
               Id = 3,
               Name = "iPhone 16 pro max",
               Price = 90000
           },
        ];
    public IEnumerable<Product> GetAll() => _products;

    public Product? Get(int id) => _products.SingleOrDefault(p => p.Id == id);
  
    public Product Add(Product product)
    {
        _products.Add(product);
        return product;
    }
    public bool Update(int id, Product product)
    {
        var currentProduct = Get(id);

        if (currentProduct == null) 
            return false;

        currentProduct.Name = product.Name;
        currentProduct.Price = product.Price;

        return true;
    }
    public bool Delete(int id)
    {
        var product = Get(id);
        if(product is null)
            return false;

        _products.Remove(product);
        return true;
    }
}
