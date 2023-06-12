using Smartwyre.DeveloperTest.Data.GenericDataRepo;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.ProductDataStore
{
    public class ProductDataStore : IProductDataStore
    {
        private IGenericEntityRepo<Product> _genericEntityRepo;

        ProductDataStore(IGenericEntityRepo<Product> genericEntityRepo)
        {
            _genericEntityRepo = genericEntityRepo;
        }

        public Product GetProduct(string identifier)
        {
            return _genericEntityRepo.GetEntityData(identifier);
        }
    }
}
