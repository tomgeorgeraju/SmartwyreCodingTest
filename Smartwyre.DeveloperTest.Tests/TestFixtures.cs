using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests
{
    public class TestFixtures
    {
        public Rebate rebate = new Rebate { Identifier = "FakeRebateIdentifier", Incentive = IncentiveType.FixedCashAmount };
        public Product product = new Product { Identifier = "FakeProductIdentifier", SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        public CalculateRebateRequest calculateRebateRequest = new CalculateRebateRequest
        {
            ProductIdentifier = "FakeProductIdentifier"
        ,
            RebateIdentifier = "FakeRebateIdentifier"
        };
        public CalculateRebateResult expectedFalseResult = new CalculateRebateResult { Success = false };
        public decimal expectedRebateAmount = 0m;
    }
}
