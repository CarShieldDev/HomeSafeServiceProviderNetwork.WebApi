using HomeSafeServiceProviderNetwork.WebApi.Data.Context;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces;
using HomeSafeServiceProviderNetwork.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HomeSafeServiceProviderNetwork.WebApi.Interfaces
{
    public interface IHspnRepository
    {
        Task<IReadOnlyList<HspnBrand>> GetBrandsAsync();
        Task<IReadOnlyList<HspnBrand>> GetBrandByIdAsync(int brandId);
        Task<IReadOnlyList<HspnCity>> GetCitiesByStateCodeAsync(string stateCode);
        Task<IReadOnlyList<HspnCity>> GetCityByIdAsync(int cityId);
        Task<IReadOnlyList<HspnCounty>> GetCountiesByStateCodeAsync(string stateCode);
        Task<IReadOnlyList<HspnCounty>> GetCountyByFipsAsync(string countyFips);
        Task<IReadOnlyList<HspnCoupon>> GetCouponsAsync();
        Task<IReadOnlyList<HspnCoupon>> GetCouponByIdAsync(int couponId);
        Task<int> InsertCouponsAsync(HspnCouponsModel coupons);
        Task<IReadOnlyList<HspnFormType>> GetFormTypesAsync();
        Task<IReadOnlyList<HspnFormType>> GetFormTypeByIdAsync(int formTypeId);
        Task<IReadOnlyList<HspnFormType>> GetFormTypesByTypeAsync(string formType);
        Task<IReadOnlyList<HspnHourOfOperation>> GetHoursOfOperationAsync();
        Task<IReadOnlyList<HspnHourOfOperation>> GetHourOfOperationByIdAsync(int hourOfOperationId);
        Task<int> InsertHoursOfOperationAsync(HspnHoursOfOperationModel hoursOfOperation);
        Task<IReadOnlyList<HspnNetworkStatus>> GetNetworkStatusesAsync();
        Task<IReadOnlyList<HspnNetworkStatus>> GetNetworkStatusByIdAsync(int newtworkStatusId);
        Task<IReadOnlyList<HspnServiceableItem>> GetServiceableItemsAsync();
        Task<IReadOnlyList<HspnServiceableItem>> GetServiceableItemByIdAsync(int serviceableItemId);
        Task<IReadOnlyList<HspnServiceableItemType>> GetServiceableItemTypesAsync();
        Task<IReadOnlyList<HspnServiceableItemType>> GetServiceableItemTypeByIdAsync(int serviceableItemTypeId);
        Task<IReadOnlyList<HspnServicedItem>> GetServicedItemsAsync();
        Task<IReadOnlyList<HspnServicedItem>> GetServicedItemByIdAsync(int servicedItemId);
        Task<int> InsertServicedItemsAsync(List<HspnServicedItem> servicedItems);
        Task<IReadOnlyList<HspnServicedLocation>> GetServicedLocationsAsync();
        Task<IReadOnlyList<HspnServicedLocation>> GetServicedLocationByIdAsync(int servicedLocationId);
        Task<int> InsertServicedLocationsAsync(List<HspnServicedLocation> hoursOfOperation);
        Task<IReadOnlyList<HspnServiceProvider>> GetServiceProvidersAsync();
        Task<IReadOnlyList<HspnServiceProvider>> GetServiceProviderByIdAsync(int serviceProviderId);
        Task<IActionResult> DeleteServiceProviderAsync(int serviceProviderId);
        Task<IEnumerable<HspnServiceProvider>> GetServiceProviderInfoAsync(int serviceProviderId);
        Task<int> InsertServiceProviderAsync(HspnServiceProviderModel serviceProviderInsert);
        Task<IReadOnlyList<HspnShopType>> GetShopTypesAsync();
        Task<IReadOnlyList<HspnShopType>> GetShopTypeByIdAsync(int shopTypeId);
        Task<IReadOnlyList<HspnState>> GetStatesAsync();
        Task<IReadOnlyList<HspnState>> GetStateByCodeAsync(string stateCode);
        Task<IReadOnlyList<HspnZip>> GetZipCodesAsync();
        Task<IReadOnlyList<HspnZip>> GetZipCodesByStateCodeAsync(string stateCode);
    }
}