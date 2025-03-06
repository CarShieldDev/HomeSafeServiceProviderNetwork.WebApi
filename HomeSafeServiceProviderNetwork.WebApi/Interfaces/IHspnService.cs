using HomeSafeServiceProviderNetwork.WebApi.Models;
using HomeSafeServiceProviderNetwork.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeSafeServiceProviderNetwork.WebApi.Interfaces
{
    public interface IHspnService
    {
        Task<IEnumerable<HspnBrand>> GetBrandsAsync();
        Task<IEnumerable<HspnBrand>> GetBrandByIdAsync(int brandId);
        Task<IEnumerable<HspnCity>> GetCitiesByStateCodeAsync(string stateCode);
        Task<IEnumerable<HspnCity>> GetCityByIdAsync(int cityId);
        Task<IEnumerable<HspnCounty>> GetCountiesByStateCodeAsync(string stateCode);
        Task<IEnumerable<HspnCounty>> GetCountyByFipsAsync(string countyFips);
        Task<IEnumerable<HspnCoupon>> GetCouponsAsync();
        Task<IEnumerable<HspnCoupon>> GetCouponByIdAsync(int couponId);
        Task<int> InsertCouponsAsync(HspnCouponsModel coupons);
        Task<IEnumerable<HspnFormType>> GetFormTypesAsync();
        Task<IEnumerable<HspnFormType>> GetFormTypeByIdAsync(int formTypeId);
        Task<IEnumerable<HspnFormType>> GetFormTypesByTypeAsync(string formType);
        Task<IEnumerable<HspnHourOfOperation>> GetHoursOfOperationAsync();
        Task<IEnumerable<HspnHourOfOperation>> GetHourOfOperationByIdAsync(int hourOfOperationId);
        Task<int> InsertHoursOfOperationAsync(HspnHoursOfOperationModel hoursOfOperation);
        Task<IEnumerable<HspnNetworkStatus>> GetNetworkStatusesAsync();
        Task<IEnumerable<HspnNetworkStatus>> GetNetworkStatusByIdAsync(int networkStatusId);
        Task<IEnumerable<HspnServiceableItem>> GetServiceableItemsAsync();
        Task<IEnumerable<HspnServiceableItem>> GetServiceableItemByIdAsync(int serviceableItemId);
        Task<IEnumerable<HspnServiceableItemType>> GetServiceableItemTypesAsync();
        Task<IEnumerable<HspnServiceableItemType>> GetServiceableItemTypeByIdAsync(int serviceableItemTypeId);
        Task<IEnumerable<HspnServicedItem>> GetServicedItemsAsync();
        Task<IEnumerable<HspnServicedItem>> GetServicedItemByIdAsync(int servicedItemId);
        Task<int> InsertServicedItemsAsync(List<HspnServicedItem> servicedItems);
        Task<IEnumerable<HspnServicedLocation>> GetServicedLocationsAsync();
        Task<IEnumerable<HspnServicedLocation>> GetServicedLocationByIdAsync(int servicedLocationId);
        Task<int> InsertServicedLocationsAsync(List<HspnServicedLocation> servicedLocations);
        Task<IEnumerable<HspnServiceProvider>> GetServiceProvidersAsync();
        Task<IEnumerable<HspnServiceProvider>> GetServiceProviderByIdAsync(int serviceProviderId);
        Task<int> DeleteServiceProviderAsync(int serviceProviderId);
        Task<IEnumerable<HspnServiceProviderInfo>> GetServiceProviderInfoAsync(int serviceProviderId);
        Task<int> InsertServiceProviderAsync(HspnServiceProviderModel serviceProviderInsert);
        Task<IEnumerable<HspnShopType>> GetShopTypesAsync();
        Task<IEnumerable<HspnShopType>> GetShopTypeByIdAsync(int shopTypeId);
        Task<IEnumerable<HspnState>> GetStatesAsync();
        Task<IEnumerable<HspnState>> GetStateByStateCodeAsync(string stateCode);
        Task<IEnumerable<HspnZip>> GetZipCodesAsync();
        Task<IEnumerable<HspnZip>> GetZipCodesByStateCodeAsync(string stateCode);
    }
}
