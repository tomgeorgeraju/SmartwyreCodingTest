using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.FactoryServices
{
    public class AmountPerUomService: ISupportedIncentiveService
    {
        public Tuple<CalculateRebateResult, decimal> CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var rebateAmount = 0m;
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else if (rebate.Amount == 0 || request.Volume == 0)
            {
                return Tuple.Create(new CalculateRebateResult { Success = false }, rebateAmount);
            }
            else
            {
                rebateAmount += rebate.Amount * request.Volume;
                return Tuple.Create(new CalculateRebateResult { Success = true }, rebateAmount);
            }
        }
    }
}
