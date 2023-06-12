using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.ProductDataStore
{
    public interface IProductDataStore
    {
        Product GetProduct(string identifier);
    }
}
