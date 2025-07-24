namespace Demo.api.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? Get(int id);
    Product Add(Product product);
    bool Update(int id , Product product);
    bool Delete(int id);

}
