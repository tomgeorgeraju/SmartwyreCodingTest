using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.FactoryServices
{
    internal class FixedRateRebateService: ISupportedIncentiveService
    {
        public Tuple<CalculateRebateResult, decimal> CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var rebateAmount = 0m;
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else
            {
                rebateAmount += product.Price * rebate.Percentage * request.Volume;
                return Tuple.Create(new CalculateRebateResult { Success = true }, rebateAmount);
            }
        }
    }
}
