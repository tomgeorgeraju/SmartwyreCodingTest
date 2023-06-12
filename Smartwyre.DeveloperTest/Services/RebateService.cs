using Microsoft.VisualBasic;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.ProductDataStore;
using Smartwyre.DeveloperTest.Data.RebateDataStore;
using Smartwyre.DeveloperTest.Extensions;
using Smartwyre.DeveloperTest.FactoryServices;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {

        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        var rebateAmount = 0m;
        var result = new CalculateRebateResult();

        if (rebate.IsNull() || product.IsNull())
        {
            result.Success = false;
        }
        else
        {
            var service = FactoryHandler.GetIncentiveService(rebate.Incentive);

            (result, rebateAmount) = service.CalculateRebate(rebate, product, request);
        }

        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }
}
