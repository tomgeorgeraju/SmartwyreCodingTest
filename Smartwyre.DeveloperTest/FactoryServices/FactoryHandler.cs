using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.FactoryServices
{
    internal static class FactoryHandler
    {
        public static ISupportedIncentiveService GetIncentiveService(IncentiveType incentiveType)
        {
            switch (incentiveType)
            {
                case IncentiveType.FixedCashAmount:

                    return new FixedCashAmountService();
                    

                case IncentiveType.FixedRateRebate:

                    return new FixedRateRebateService();
                   

                case IncentiveType.AmountPerUom:

                    return new AmountPerUomService();

                default:

                    throw new NotImplementedException();
            }
        }
    }
}
