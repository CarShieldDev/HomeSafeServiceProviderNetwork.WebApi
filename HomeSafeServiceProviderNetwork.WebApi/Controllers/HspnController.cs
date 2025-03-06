using HomeSafeServiceProviderNetwork.WebApi.Interfaces;
using HomeSafeServiceProviderNetwork.WebApi.Models;
using HomeSafeServiceProviderNetwork.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeSafeServiceProviderNetwork.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HspnController : ControllerBase
    {
        private readonly ILogger<HspnController> _logger;
        private readonly IHspnService _hspnService;

        public HspnController(ILogger<HspnController> logger, IHspnService hspnService)
        {
            _logger = logger;
            _hspnService = hspnService;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrandsAsync()
        {
            var result = await _hspnService.GetBrandsAsync();
            return Ok(result);
        }

        [HttpGet("GetBrandById")]
        public async Task<IActionResult> GetBrandByIdAsync(int brandId)
        {
            var result = await _hspnService.GetBrandByIdAsync(brandId);
            return Ok(result);
        }

        [HttpGet("GetCitiesByStateCode")]
        public async Task<IActionResult> GetCitiesAsync(string stateCode)
        {
            var result = await _hspnService.GetCitiesByStateCodeAsync(stateCode);
            return Ok(result);
        }

        [HttpGet("GetCityById")]
        public async Task<IActionResult> GetCityByIdAsync(int cityId)
        {
            var result = await _hspnService.GetCityByIdAsync(cityId);
            return Ok(result);
        }

        [HttpGet("GetCountiesByStateCode")]
        public async Task<IActionResult> GetCountiesByStateCodeAsync(string stateCode)
        {
            var result = await _hspnService.GetCountiesByStateCodeAsync(stateCode);
            return Ok(result);
        }

        [HttpGet("GetCountyByFips")]
        public async Task<IActionResult> GetCountyByFipsAsync(string countyFips)
        {
            var result = await _hspnService.GetCountyByFipsAsync(countyFips);
            return Ok(result);
        }

        [HttpGet("GetCoupons")]
        public async Task<IActionResult> GetCouponsAsync()
        {
            var result = await _hspnService.GetCouponsAsync();
            return Ok(result);
        }

        [HttpGet("GetCouponById")]
        public async Task<IActionResult> GetCouponByIdAsync(int couponId)
        {
            var result = await _hspnService.GetCouponByIdAsync(couponId);
            return Ok(result);
        }

        [HttpPost("InsertCoupons")]
        public async Task<IActionResult> InsertCouponsAsync(HspnCouponsModel coupons)
        {
            var result = await _hspnService.InsertCouponsAsync(coupons);
            return Ok(result);
        }

        [HttpGet("GetFormTypes")]
        public async Task<IActionResult> GetFormTypesAsync()
        {
            var result = await _hspnService.GetFormTypesAsync();
            return Ok(result);
        }

        [HttpGet("GetFormTypeById")]
        public async Task<IActionResult> GetFormTypeByIdAsync(int formTypeId)
        {
            var result = await _hspnService.GetFormTypeByIdAsync(formTypeId);
            return Ok(result);
        }

        [HttpGet("GetFormTypesByType")]
        public async Task<IActionResult> GetFormTypeByIdAsync(string formType)
        {
            var result = await _hspnService.GetFormTypesByTypeAsync(formType);
            return Ok(result);
        }

        [HttpGet("GetHoursOfOperation")]
        public async Task<IActionResult> GetHoursOfOperationAsync()
        {
            var result = await _hspnService.GetHoursOfOperationAsync();
            return Ok(result);
        }

        [HttpGet("GetHourOfOperationById")]
        public async Task<IActionResult> GetHourOfOperationByIdAsync(int hourOfOperationId)
        {
            var result = await _hspnService.GetHourOfOperationByIdAsync(hourOfOperationId);
            return Ok(result);
        }

        [HttpPost("InsertHoursOfOperation")]
        public async Task<IActionResult> GetHourOfOperationAsync(HspnHoursOfOperationModel hoursOfOperation)
        {
            var result = await _hspnService.InsertHoursOfOperationAsync(hoursOfOperation);
            return Ok(result);
        }

        [HttpGet("GetNetworkStatuses")]
        public async Task<IActionResult> GetNetworkStatusesAsync()
        {
            var result = await _hspnService.GetNetworkStatusesAsync();
            return Ok(result);
        }

        [HttpGet("GetNetworkStatusById")]
        public async Task<IActionResult> GetNetworkStatusByIdAsync(int networkStatusId)
        {
            var result = await _hspnService.GetNetworkStatusByIdAsync(networkStatusId);
            return Ok(result);
        }

        [HttpGet("GetServiceableItems")]
        public async Task<IActionResult> GetServiceableItemsAsync()
        {
            var result = await _hspnService.GetServiceableItemsAsync();
            return Ok(result);
        }

        [HttpGet("GetServiceableItemById")]
        public async Task<IActionResult> GetServiceableItemByIdAsync(int serviceableItemId)
        {
            var result = await _hspnService.GetServiceableItemByIdAsync(serviceableItemId);
            return Ok(result);
        }

        [HttpGet("GetServiceableItemTypes")]
        public async Task<IActionResult> GetServiceableItemTypesAsync()
        {
            var result = await _hspnService.GetServiceableItemTypesAsync();
            return Ok(result);
        }

        [HttpGet("GetServiceableItemTypeById")]
        public async Task<IActionResult> GetServiceableItemTypeByIdAsync(int serviceableItemTypeId)
        {
            var result = await _hspnService.GetServiceableItemTypeByIdAsync(serviceableItemTypeId);
            return Ok(result);
        }

        [HttpGet("GetServicedItems")]
        public async Task<IActionResult> GetServicedItemsAsync()
        {
            var result = await _hspnService.GetServicedItemsAsync();
            return Ok(result);
        }

        [HttpGet("GetServicedItemById")]
        public async Task<IActionResult> GetServicedItemByIdAsync(int servicedItemId)
        {
            var result = await _hspnService.GetServicedItemByIdAsync(servicedItemId);
            return Ok(result);
        }

        [HttpPost("InsertServicedItems")]
        public async Task<IActionResult> InsertServicedItemsAsync(List<HspnServicedItem> servicedItems)
        {
            var result = await _hspnService.InsertServicedItemsAsync(servicedItems);
            return Ok(result);
        }

        [HttpGet("GetServicedLocations")]
        public async Task<IActionResult> GetServicedLocationsAsync()
        {
            var result = await _hspnService.GetServicedLocationsAsync();
            return Ok(result);
        }

        [HttpGet("GetServicedLocationById")]
        public async Task<IActionResult> GetServicedLocationByIdAsync(int servicedLocationId)
        {
            var result = await _hspnService.GetServicedLocationByIdAsync(servicedLocationId);
            return Ok(result);
        }

        [HttpPost("InsertServicedLocations")]
        public async Task<IActionResult> InsertServicedLocationsAsync(List<HspnServicedLocation> servicedLocations)
        {
            var result = await _hspnService.InsertServicedLocationsAsync(servicedLocations);
            return Ok(result);
        }

        [HttpGet("GetServiceProviders")]
        public async Task<IActionResult> GetServiceProvidersAsync()
        {
            var result = await _hspnService.GetServiceProvidersAsync();
            return Ok(result);
        }

        [HttpGet("GetServiceProviderById")]
        public async Task<IActionResult> GetServiceProviderByIdAsync(int serviceProviderId)
        {
            var result = await _hspnService.GetServiceProviderByIdAsync(serviceProviderId);
            return Ok(result);
        }

        [HttpPost("DeleteServiceProvider")]
        public async Task<IActionResult> DeleteServiceProviderAsync(int serviceProviderId)
        {
            var result = await _hspnService.DeleteServiceProviderAsync(serviceProviderId);
            return Ok(result);
        }

        [HttpGet("GetServiceProviderInfo")]
        public async Task<IActionResult> GetServiceProviderInfoAsync(int serviceProviderId)
        {
            var result = await _hspnService.GetServiceProviderInfoAsync(serviceProviderId);
            return Ok(result);
        }

        [HttpPost("InsertServiceProvider")]
        public async Task<IActionResult> InsertServiceProviderAsync(HspnServiceProviderModel serviceProviderInsert)
        {
            var result = await _hspnService.InsertServiceProviderAsync(serviceProviderInsert);
            return Ok(result);
        }

        [HttpGet("GetShopTypes")]
        public async Task<IActionResult> GetShopTypesAsync()
        {
            var result = await _hspnService.GetShopTypesAsync();
            return Ok(result);
        }

        [HttpGet("GetShopTypeById")]
        public async Task<IActionResult> GetShopTypeByIdAsync(int shopTypeId)
        {
            var result = await _hspnService.GetShopTypeByIdAsync(shopTypeId);
            return Ok(result);
        }

        [HttpGet("GetStates")]
        public async Task<IActionResult> GetStatesAsync()
        {
            var result = await _hspnService.GetStatesAsync();
            return Ok(result);
        }

        [HttpGet("GetStateByStateCode")]
        public async Task<IActionResult> GetStateByStateCodeAsync(string stateCode)
        {
            var result = await _hspnService.GetStateByStateCodeAsync(stateCode);
            return Ok(result);
        }

        //[HttpGet("GetZipCodes")]
        //public async Task<IActionResult> GetZipCodesAsync()
        //{
        //    var result = await _hspnService.GetZipCodesAsync();
        //    return Ok(result);
        //}

        [HttpGet("GetZipCodesByStateCode")]
        public async Task<IActionResult> GetZipCodesByStateCodeAsync(string stateCode)
        {
            var result = await _hspnService.GetZipCodesByStateCodeAsync(stateCode);
            return Ok(result);
        }
    }
}
