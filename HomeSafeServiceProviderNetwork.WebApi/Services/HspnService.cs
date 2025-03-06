using HomeSafeServiceProviderNetwork.WebApi.Models;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSafeServiceProviderNetwork.WebApi.Services
{
    public class HspnService : IHspnService
    {
        private readonly ILogger<HspnService> _logger;
        private readonly IHspnRepository _hspnRepository;

        public HspnService(ILogger<HspnService> logger, IHspnRepository hspnRepository)
        {
            _logger = logger;
            _hspnRepository = hspnRepository;
        }

        public async Task<IEnumerable<HspnBrand>> GetBrandsAsync()
        {
            try
            {
                var brands = await _hspnRepository.GetBrandsAsync();
                return brands;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetBrandsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnBrand>> GetBrandByIdAsync(int brandId)
        {
            try
            {
                var brand = await _hspnRepository.GetBrandByIdAsync(brandId);
                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetBrandsByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCity>> GetCitiesByStateCodeAsync(string stateCode)
        {
            try
            {
                var cities = await _hspnRepository.GetCitiesByStateCodeAsync(stateCode);
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCitiesByStateCodeAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCity>> GetCityByIdAsync(int cityId)
        {
            try
            {
                var city = await _hspnRepository.GetCityByIdAsync(cityId);
                return city;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCityByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCounty>> GetCountiesByStateCodeAsync(string stateCode)
        {
            try
            {
                var counties = await _hspnRepository.GetCountiesByStateCodeAsync(stateCode);
                return counties;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCountiesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCounty>> GetCountyByFipsAsync(string countyFips)
        {
            try
            {
                var county = await _hspnRepository.GetCountyByFipsAsync(countyFips);
                return county;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCountyByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCoupon>> GetCouponsAsync()
        {
            try
            {
                var coupons = await _hspnRepository.GetCouponsAsync();
                return coupons;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCouponsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnCoupon>> GetCouponByIdAsync(int couponId)
        {
            try
            {
                var coupon = await _hspnRepository.GetCouponByIdAsync(couponId);
                return coupon;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCouponByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<int> InsertCouponsAsync(HspnCouponsModel coupons)
        {
            try
            {
                var result = await _hspnRepository.InsertCouponsAsync(coupons);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertCouponsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnFormType>> GetFormTypesAsync()
        {
            try
            {
                var formTypes = await _hspnRepository.GetFormTypesAsync();
                return formTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetFormTypesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnFormType>> GetFormTypeByIdAsync(int formTypeId)
        {
            try
            {
                var formType = await _hspnRepository.GetFormTypeByIdAsync(formTypeId);
                return formType;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetFormTypeByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnFormType>> GetFormTypesByTypeAsync(string formType)
        {
            try
            {
                var formTypes = await _hspnRepository.GetFormTypesByTypeAsync(formType);
                return formTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetFormTypesByTypeAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnHourOfOperation>> GetHoursOfOperationAsync()
        {
            try
            {
                var hoursOfOperation = await _hspnRepository.GetHoursOfOperationAsync();
                return hoursOfOperation;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetHoursOfOperationAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnHourOfOperation>> GetHourOfOperationByIdAsync(int hourOfOperationId)
        {
            try
            {
                var hourOfOperation = await _hspnRepository.GetHourOfOperationByIdAsync(hourOfOperationId);
                return hourOfOperation;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetHourOfOperationByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<int> InsertHoursOfOperationAsync(HspnHoursOfOperationModel hoursOfOperation)
        {
            try
            {
                var result = await _hspnRepository.InsertHoursOfOperationAsync(hoursOfOperation);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertHoursOfOperationAsync Service Error: ", ex);
                throw;
            }
        }


        public async Task<IEnumerable<HspnNetworkStatus>> GetNetworkStatusesAsync()
        {
            try
            {
                var networkStatuses = await _hspnRepository.GetNetworkStatusesAsync();
                return networkStatuses;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetNetworkStatusesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnNetworkStatus>> GetNetworkStatusByIdAsync(int networkStatusId)
        {
            try
            {
                var networkStatus = await _hspnRepository.GetNetworkStatusByIdAsync(networkStatusId);
                return networkStatus;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetNetworkStatusByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceableItem>> GetServiceableItemsAsync()
        {
            try
            {
                var serviceableItems = await _hspnRepository.GetServiceableItemsAsync();
                return serviceableItems;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceableItemsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceableItem>> GetServiceableItemByIdAsync(int serviceableItemId)
        {
            try
            {
                var serviceableItem = await _hspnRepository.GetServiceableItemByIdAsync(serviceableItemId);
                return serviceableItem;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceableItemByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceableItemType>> GetServiceableItemTypesAsync()
        {
            try
            {
                var serviceableItemTypes = await _hspnRepository.GetServiceableItemTypesAsync();
                return serviceableItemTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceableItemTypesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceableItemType>> GetServiceableItemTypeByIdAsync(int serviceableItemTypeId)
        {
            try
            {
                var serviceableItemType = await _hspnRepository.GetServiceableItemTypeByIdAsync(serviceableItemTypeId);
                return serviceableItemType;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceableItemTypeByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServicedItem>> GetServicedItemsAsync()
        {
            try
            {
                var servicedItems = await _hspnRepository.GetServicedItemsAsync();
                return servicedItems;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServicedItemsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServicedItem>> GetServicedItemByIdAsync(int servicedItemId)
        {
            try
            {
                var servicedItem = await _hspnRepository.GetServicedItemByIdAsync(servicedItemId);
                return servicedItem;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServicedItemByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<int> InsertServicedItemsAsync(List<HspnServicedItem> servicedItems)
        {
            try
            {
                var result = await _hspnRepository.InsertServicedItemsAsync(servicedItems);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertServicedItemsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServicedLocation>> GetServicedLocationsAsync()
        {
            try
            {
                var servicedLocations = await _hspnRepository.GetServicedLocationsAsync();
                return servicedLocations;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServicedLocationsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServicedLocation>> GetServicedLocationByIdAsync(int servicedLocationId)
        {
            try
            {
                var servicedLocation = await _hspnRepository.GetServicedLocationByIdAsync(servicedLocationId);
                return servicedLocation;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServicedLocationByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<int> InsertServicedLocationsAsync(List<HspnServicedLocation> servicedLocations)
        {
            try
            {
                var result = await _hspnRepository.InsertServicedLocationsAsync(servicedLocations);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertServicedLocationsAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceProvider>> GetServiceProvidersAsync()
        {
            try
            {
                var serviceProviders = await _hspnRepository.GetServiceProvidersAsync();
                return serviceProviders;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceProvidersAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceProvider>> GetServiceProviderByIdAsync(int serviceProviderId)
        {
            try
            {
                var serviceProvider = await _hspnRepository.GetServiceProviderByIdAsync(serviceProviderId);
                return serviceProvider;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceProviderByIdAsync Service Error: ", ex);
                throw;
            }
        }


        public async Task<int> DeleteServiceProviderAsync(int serviceProviderId)
        {
            try
            {
                var result = await _hspnRepository.DeleteServiceProviderAsync(serviceProviderId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteServiceProviderAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnServiceProviderInfo>> GetServiceProviderInfoAsync(int serviceProviderId)
        {
            try
            {

                var result = await _hspnRepository.GetServiceProviderInfoAsync(serviceProviderId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetServiceProviderInfoAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<int> InsertServiceProviderAsync(HspnServiceProviderModel serviceProviderInsert)
        {
            try
            {
                var result = await _hspnRepository.InsertServiceProviderAsync(serviceProviderInsert);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertServiceProviderAsync Service Error: ", ex);
                throw;
            }
        }


        public async Task<IEnumerable<HspnShopType>> GetShopTypesAsync()
        {
            try
            {
                var shopTypes = await _hspnRepository.GetShopTypesAsync();
                return shopTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetShopTypesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnShopType>> GetShopTypeByIdAsync(int shopTypeId)
        {
            try
            {
                var shopType = await _hspnRepository.GetShopTypeByIdAsync(shopTypeId);
                return shopType;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetShopTypeByIdAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnState>> GetStatesAsync()
        {
            try
            {
                var states = await _hspnRepository.GetStatesAsync();
                return states;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetStatesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnState>> GetStateByStateCodeAsync(string stateCode)
        {
            try
            {
                var state = await _hspnRepository.GetStateByCodeAsync(stateCode);
                return state;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetStateByStateCodeAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnZip>> GetZipCodesAsync()
        {
            try
            {
                var zipCodes = await _hspnRepository.GetZipCodesAsync();
                return zipCodes;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetZipCodesAsync Service Error: ", ex);
                throw;
            }
        }

        public async Task<IEnumerable<HspnZip>> GetZipCodesByStateCodeAsync(string stateCode)
        {
            try
            {
                var zipCode = await _hspnRepository.GetZipCodesByStateCodeAsync(stateCode);
                return zipCode;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetZipCodesByStateCodeAsync Service Error: ", ex);
                throw;
            }
        }
    }
}
