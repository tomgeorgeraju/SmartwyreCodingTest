using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.RebateDataStore
{
    public interface IRebateDataStore
    {
        void StoreCalculationResult(Rebate account, decimal rebateAmount);

        Rebate GetRebate(string identifier);
    }
}
