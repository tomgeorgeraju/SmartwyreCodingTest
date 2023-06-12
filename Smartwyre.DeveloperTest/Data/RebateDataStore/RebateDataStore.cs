using Smartwyre.DeveloperTest.Data.GenericDataRepo;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.RebateDataStore
{
    public class RebateDataStore : IRebateDataStore
    {
        private IGenericEntityRepo<Rebate> _genericEntityRepo;

        RebateDataStore(IGenericEntityRepo<Rebate> genericEntityRepo)
        {
            _genericEntityRepo = genericEntityRepo;
        }

        public Rebate GetRebate(string identifier)
        {
            return _genericEntityRepo.GetEntityData(identifier);
        }
        public void StoreCalculationResult(Rebate account, decimal rebateAmount)
        {
            // Update account in database, code removed for brevity
        }
    }
}
