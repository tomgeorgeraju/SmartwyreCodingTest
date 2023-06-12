using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.FactoryServices
{
    internal class FixedCashAmountService: ISupportedIncentiveService
    {
        public Tuple<CalculateRebateResult,decimal> CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var rebateAmount = 0m;
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else if (rebate.Amount == 0)
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else
            {
                rebateAmount = rebate.Amount;
                return Tuple.Create(new CalculateRebateResult { Success = true }, rebateAmount);
            }
        }
    }
}
