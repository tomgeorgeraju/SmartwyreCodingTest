using Moq;
using Newtonsoft.Json;
using Smartwyre.DeveloperTest.Data.ProductDataStore;
using Smartwyre.DeveloperTest.Data.RebateDataStore;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests : TestFixtures
{
    Mock<IRebateDataStore> rebateDataStoreMoq = new Mock<IRebateDataStore>();
    Mock<IProductDataStore> productDataStore = new Mock<IProductDataStore>();

    [Fact]
    public void When_IncentiveType_Is_FixedCashAmount_Amount_Is_Zero_And_SupportedIncentiveType_Is_FixedCashAmount_Amount()
    {
        //Arrange
        RebateService rebateService = new RebateService(rebateDataStoreMoq.Object, productDataStore.Object);
        rebateDataStoreMoq.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        productDataStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);

        //Act
        var output = rebateService.Calculate(calculateRebateRequest);

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expectedFalseResult), JsonConvert.SerializeObject(output));
    }

    [Fact]
    public void When_Rebate_Or_Product_Is_Null()
    {
        //Arrange
        RebateService rebateService = new RebateService(rebateDataStoreMoq.Object, productDataStore.Object);
        rebateDataStoreMoq.Setup(x => x.GetRebate(It.IsAny<string>()));
        productDataStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);

        //Act
        var output = rebateService.Calculate(calculateRebateRequest);

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expectedFalseResult), JsonConvert.SerializeObject(output));
    }

    [Theory]
    [InlineData(IncentiveType.FixedCashAmount, SupportedIncentiveType.FixedCashAmount, 0, false)]
    [InlineData(IncentiveType.FixedCashAmount, SupportedIncentiveType.AmountPerUom, 0, false)]
    [InlineData(IncentiveType.FixedCashAmount, SupportedIncentiveType.FixedCashAmount, 5, true)]
    public void When_IncentiveType_Is_FixedCashAmount_And_Possible_Cases(IncentiveType incentiveType,
        SupportedIncentiveType supportedIncentiveType,
        decimal amount, bool expectedStatusflag)
    {
        //Arrange
        rebate = new Rebate { Identifier = "FakeRebateIdentifier", Incentive = incentiveType, Amount = amount };
        product = new Product { Identifier = "FakeProductIdentifier", SupportedIncentives = supportedIncentiveType };
        var expectedResult = new CalculateRebateResult { Success = expectedStatusflag };
        RebateService rebateService = new RebateService(rebateDataStoreMoq.Object, productDataStore.Object);
        rebateDataStoreMoq.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        productDataStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);

        //Act
        var output = rebateService.Calculate(calculateRebateRequest);

        //Assert
        if(amount != 0)
        {
            rebateDataStoreMoq.Verify(x => x.StoreCalculationResult(rebate, amount), Times.Once);
        }
        Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(output));
    }
}
