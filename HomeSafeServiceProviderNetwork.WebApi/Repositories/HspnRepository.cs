using Dapper;
using HomeSafeServiceProviderNetwork.WebApi.Data.Context;
using HomeSafeServiceProviderNetwork.WebApi.Interfaces;
using HomeSafeServiceProviderNetwork.WebApi.Models;
using HomeSafeServiceProviderNetwork.WebApi.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeSafeServiceProviderNetwork.WebApi.Repositories
{
    public class HspnRepository : IHspnRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly HspnContext _hspnContext;
        private readonly ILogger<HspnRepository> _logger;

        #endregion

        #region ===[ Constructor ]=================================================================

        public HspnRepository(ILogger<HspnRepository> logger, IConfiguration configuration, HspnContext hspnContext)
        {
            _logger = logger;
            _configuration = configuration;
            _hspnContext = hspnContext;

        }

        #endregion

        #region ===[ IHspnRepository Methods ]==================================================

        /// <summary>
        /// Get the list of Brands
        /// </summary>
        /// <returns>List of brand records</returns>
        public async Task<IReadOnlyList<HspnBrand>> GetBrandsAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnBrand>)await connection.QueryAsync<HspnBrand>(HspnQueries.GetBrands);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get Brand by BrandId
        /// </summary>
        /// <returns>Single brand record</returns>
        public async Task<IReadOnlyList<HspnBrand>> GetBrandByIdAsync(int brandId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnBrand>)await connection.QueryAsync<HspnBrand>(HspnQueries.GetBrandById, new { BrandID = brandId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of Cities
        /// </summary>
        /// <returns>List of city records</returns>
        public async Task<IReadOnlyList<HspnCity>> GetCitiesByStateCodeAsync(string stateCode)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCity>)await connection.QueryAsync<HspnCity>(HspnQueries.GetCities, new { StateCode = stateCode });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get City by CityId
        /// </summary>
        /// <returns>Single city record</returns>
        public async Task<IReadOnlyList<HspnCity>> GetCityByIdAsync(int cityId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCity>)await connection.QueryAsync<HspnCity>(HspnQueries.GetCityById, new { CityID = cityId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of Counties
        /// </summary>
        /// <returns>List of brand records</returns>
        public async Task<IReadOnlyList<HspnCounty>> GetCountiesByStateCodeAsync(string stateCode)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCounty>)await connection.QueryAsync<HspnCounty>(HspnQueries.GetCountiesByStateCode, new { StateCode = stateCode });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get County by CountyId
        /// </summary>
        /// <returns>Single brand record</returns>
        public async Task<IReadOnlyList<HspnCounty>> GetCountyByFipsAsync(string countyFips)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCounty>)await connection.QueryAsync<HspnCounty>(HspnQueries.GetCountyByFips, new { CountyFIPS = countyFips });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of Coupons
        /// </summary>
        /// <returns>List of coupon records</returns>
        public async Task<IReadOnlyList<HspnCoupon>> GetCouponsAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCoupon>)await connection.QueryAsync<HspnCoupon>(HspnQueries.GetCoupons);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Insert Coupons
        /// </summary>
        /// <returns>List of coupons to insert</returns>
        public async Task<int> InsertCouponsAsync(HspnCouponsModel coupons)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    if (coupons.Coupons.Count > 0)
                    {
                        using (SqlCommand command = new SqlCommand("[hspn].[usp_UpsertCoupons]", (SqlConnection)connection))
                        {
                            await Task.Delay(1);
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramHoursOfOperationJSON = new SqlParameter();
                            SqlParameter paramServiceProviderId = new SqlParameter();
                            paramServiceProviderId.ParameterName = "@int_ServiceProviderID";
                            paramServiceProviderId.SqlDbType = SqlDbType.Int;
                            paramServiceProviderId.Value = coupons.ServiceProviderID;
                            paramServiceProviderId.Direction = ParameterDirection.Input;
                            command.Parameters.Add(paramServiceProviderId);

                            SqlParameter paramCouponJSON = new SqlParameter();
                            paramCouponJSON.ParameterName = "@nvch_CouponInfoJSON";
                            paramCouponJSON.SqlDbType = SqlDbType.NVarChar;
                            paramCouponJSON.Size = 10000;
                            paramCouponJSON.Direction = ParameterDirection.Input;
                            paramCouponJSON.Value = JsonSerializer.Serialize(coupons.Coupons);
                            command.Parameters.Add(paramCouponJSON);

                            SqlParameter paramCreatedBy = new SqlParameter();
                            paramCreatedBy.ParameterName = "@vch_CreatedBy";
                            paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                            paramCreatedBy.Size = 50;
                            paramCreatedBy.Direction = ParameterDirection.Input;
                            paramCreatedBy.Value = Environment.UserName;
                            command.Parameters.Add(paramCreatedBy);

                            SqlParameter paramErrorCode = new SqlParameter();
                            paramErrorCode.ParameterName = "@int_ErrorCode";
                            paramErrorCode.SqlDbType = SqlDbType.Int;
                            paramErrorCode.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorCode);

                            SqlParameter paramErrorMessage = new SqlParameter();
                            paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                            paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                            paramErrorMessage.Size = 500;
                            paramErrorMessage.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorMessage);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                                if (errorCode == 0)
                                {
                                    return errorCode;
                                }
                                else
                                {
                                    string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                    _logger.LogError($"Stored Procedure [hspn].[usp_UpsertCoupons] returned error: {errorCode} : {errorMessage}");
                                    return errorCode;
                                }
                            }
                            catch (SqlException ex)
                            {
                                _logger.LogError("SQL Exception:", ex);
                                throw;
                            }
                        }
                    }
                }
            }
            return (-1);
        }

        /// <summary>
        /// Get Coupon by CouponId
        /// </summary>
        /// <returns>Single Coupon record</returns>
        public async Task<IReadOnlyList<HspnCoupon>> GetCouponByIdAsync(int couponId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnCoupon>)await connection.QueryAsync<HspnCoupon>(HspnQueries.GetCouponById, new { CouponID = couponId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of FormTypes
        /// </summary>
        /// <returns>List of FormType records</returns>
        public async Task<IReadOnlyList<HspnFormType>> GetFormTypesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnFormType>)await connection.QueryAsync<HspnFormType>(HspnQueries.GetFormTypes);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get FormType by FormTypeId
        /// </summary>
        /// <returns>Single FormType record</returns>
        public async Task<IReadOnlyList<HspnFormType>> GetFormTypeByIdAsync(int formTypeId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnFormType>)await connection.QueryAsync<HspnFormType>(HspnQueries.GetFormTypeById, new { FormTypeID = formTypeId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get list of FormTypes by Type
        /// </summary>
        /// <returns>List of FormType records</returns>
        public async Task<IReadOnlyList<HspnFormType>> GetFormTypesByTypeAsync(string formType)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnFormType>)await connection.QueryAsync<HspnFormType>(HspnQueries.GetFormTypesByType, new { FormType = formType });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of HourOfOperations
        /// </summary>
        /// <returns>List of HourOfOperation records</returns>
        public async Task<IReadOnlyList<HspnHourOfOperation>> GetHoursOfOperationAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnHourOfOperation>)await connection.QueryAsync<HspnHourOfOperation>(HspnQueries.GetHoursOfOperation);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get Brand by BrandId
        /// </summary>
        /// <returns>Single brand record</returns>
        public async Task<IReadOnlyList<HspnHourOfOperation>> GetHourOfOperationByIdAsync(int hourOfOperationId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnHourOfOperation>)await connection.QueryAsync<HspnHourOfOperation>(HspnQueries.GetHourOfOperationById, new { HourOfOperationID = hourOfOperationId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        public async Task<int> InsertHoursOfOperationAsync(HspnHoursOfOperationModel hoursOfOperation)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    if (hoursOfOperation.HoursOfOperation.Count > 0)
                    {
                        using (SqlCommand command = new SqlCommand("[hspn].[usp_UpsertHoursOfOperation]", (SqlConnection)connection))
                        {
                            await Task.Delay(1);
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramHoursOfOperationJSON = new SqlParameter();
                            SqlParameter paramServiceProviderId = new SqlParameter();
                            paramServiceProviderId.ParameterName = "@int_ServiceProviderID";
                            paramServiceProviderId.SqlDbType = SqlDbType.Int;
                            paramServiceProviderId.Value = hoursOfOperation.ServiceProviderID;
                            paramServiceProviderId.Direction = ParameterDirection.Input;
                            command.Parameters.Add(paramServiceProviderId);

                            paramHoursOfOperationJSON.ParameterName = "@nvch_HourOfOperationInfoJSON";
                            paramHoursOfOperationJSON.SqlDbType = SqlDbType.NVarChar;
                            paramHoursOfOperationJSON.Size = 10000;
                            paramHoursOfOperationJSON.Direction = ParameterDirection.Input;
                            paramHoursOfOperationJSON.Value = JsonSerializer.Serialize(hoursOfOperation.HoursOfOperation);
                            command.Parameters.Add(paramHoursOfOperationJSON);

                            SqlParameter paramCreatedBy = new SqlParameter();
                            paramCreatedBy.ParameterName = "@vch_CreatedBy";
                            paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                            paramCreatedBy.Size = 50;
                            paramCreatedBy.Direction = ParameterDirection.Input;
                            paramCreatedBy.Value = Environment.UserName;
                            command.Parameters.Add(paramCreatedBy);

                            SqlParameter paramErrorCode = new SqlParameter();
                            paramErrorCode.ParameterName = "@int_ErrorCode";
                            paramErrorCode.SqlDbType = SqlDbType.Int;
                            paramErrorCode.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorCode);

                            SqlParameter paramErrorMessage = new SqlParameter();
                            paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                            paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                            paramErrorMessage.Size = 500;
                            paramErrorMessage.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorMessage);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                                if (errorCode == 0)
                                {
                                    return errorCode;
                                }
                                else
                                {
                                    string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                    _logger.LogError($"Stored Procedure [hspn].[usp_InsertServiceProvider] returned error: {errorCode} : {errorMessage}");
                                    return errorCode;
                                }
                            }
                            catch (SqlException ex)
                            {
                                _logger.LogError("SQL");
                            }
                        }
                    }
                }
            }
            return (-1);
        }


        /// <summary>
        /// Get the list of NetworkStatuses
        /// </summary>
        /// <returns>List of NetworkStatus records</returns>
        public async Task<IReadOnlyList<HspnNetworkStatus>> GetNetworkStatusesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnNetworkStatus>)await connection.QueryAsync<HspnNetworkStatus>(HspnQueries.GetNetworkStatuses);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get NetworkStatus by NetworkStatusId
        /// </summary>
        /// <returns>Single NetworkStatus record</returns>
        public async Task<IReadOnlyList<HspnNetworkStatus>> GetNetworkStatusByIdAsync(int networkStatusId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnNetworkStatus>)await connection.QueryAsync<HspnNetworkStatus>(HspnQueries.GetNetworkStatusById, new { NetworkStatusID = networkStatusId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of ServiceableItems
        /// </summary>
        /// <returns>List of ServiceableItem records</returns>
        public async Task<IReadOnlyList<HspnServiceableItem>> GetServiceableItemsAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceableItem>)await connection.QueryAsync<HspnServiceableItem>(HspnQueries.GetServiceableItems);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ServiceableItem by ServiceableItemId
        /// </summary>
        /// <returns>Single brand record</returns>
        public async Task<IReadOnlyList<HspnServiceableItem>> GetServiceableItemByIdAsync(int serviceableItemId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceableItem>)await connection.QueryAsync<HspnServiceableItem>(HspnQueries.GetServiceableItemById, new { ServiceableItemID = serviceableItemId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of ServiceableItemTypes
        /// </summary>
        /// <returns>List of ServiceableItemType records</returns>
        public async Task<IReadOnlyList<HspnServiceableItemType>> GetServiceableItemTypesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceableItemType>)await connection.QueryAsync<HspnServiceableItemType>(HspnQueries.GetServiceableItemTypes);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ServiceableItemType by ServiceableItemTypeId
        /// </summary>
        /// <returns>Single ServiceableItemType record</returns>
        public async Task<IReadOnlyList<HspnServiceableItemType>> GetServiceableItemTypeByIdAsync(int serviceableItemTypeId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceableItemType>)await connection.QueryAsync<HspnServiceableItemType>(HspnQueries.GetServiceableItemTypeById, new { ServiceableItemTypeID = serviceableItemTypeId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of ServicedItems
        /// </summary>
        /// <returns>List of ServicedItem records</returns>
        public async Task<IReadOnlyList<HspnServicedItem>> GetServicedItemsAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServicedItem>)await connection.QueryAsync<HspnServicedItem>(HspnQueries.GetServicedItems);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ServicedItem by ServicedItemId
        /// </summary>
        /// <returns>Single ServicedItem record</returns>
        public async Task<IReadOnlyList<HspnServicedItem>> GetServicedItemByIdAsync(int servicedItemId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServicedItem>)await connection.QueryAsync<HspnServicedItem>(HspnQueries.GetServicedItemById, new { ServicedItemID = servicedItemId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Insert ServicedItems
        /// </summary>
        /// <returns>ServicedItems to insert</returns>
        public async Task<int> InsertServicedItemsAsync(List<HspnServicedItem> servicedItems)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    if (servicedItems.Count > 0)
                    {
                        using (SqlCommand command = new SqlCommand("[hspn].[usp_UpsertServicedItems]", (SqlConnection)connection))
                        {
                            await Task.Delay(1);
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramHoursOfOperationJSON = new SqlParameter();
                            SqlParameter paramServiceProviderId = new SqlParameter();
                            paramServiceProviderId.ParameterName = "@int_ServiceProviderID";
                            paramServiceProviderId.SqlDbType = SqlDbType.Int;
                            paramServiceProviderId.Value = servicedItems[0].ServiceProviderID;
                            paramServiceProviderId.Direction = ParameterDirection.Input;
                            command.Parameters.Add(paramServiceProviderId);

                            SqlParameter paramServiceableItemJSON = new SqlParameter();
                            paramServiceableItemJSON.ParameterName = "@nvch_ServiceableItemJSON";
                            paramServiceableItemJSON.SqlDbType = SqlDbType.NVarChar;
                            paramServiceableItemJSON.Size = 10000;
                            paramServiceableItemJSON.Direction = ParameterDirection.Input;
                            paramServiceableItemJSON.Value = JsonSerializer.Serialize(servicedItems);
                            command.Parameters.Add(paramServiceableItemJSON);

                            SqlParameter paramCreatedBy = new SqlParameter();
                            paramCreatedBy.ParameterName = "@vch_CreatedBy";
                            paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                            paramCreatedBy.Size = 50;
                            paramCreatedBy.Direction = ParameterDirection.Input;
                            paramCreatedBy.Value = Environment.UserName;
                            command.Parameters.Add(paramCreatedBy);

                            SqlParameter paramErrorCode = new SqlParameter();
                            paramErrorCode.ParameterName = "@int_ErrorCode";
                            paramErrorCode.SqlDbType = SqlDbType.Int;
                            paramErrorCode.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorCode);

                            SqlParameter paramErrorMessage = new SqlParameter();
                            paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                            paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                            paramErrorMessage.Size = 500;
                            paramErrorMessage.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorMessage);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                                if (errorCode == 0)
                                {
                                    return errorCode;
                                }
                                else
                                {
                                    string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                    _logger.LogError($"Stored Procedure [hspn].[usp_UpsertServicedItems] returned error: {errorCode} : {errorMessage}");
                                    return errorCode;
                                }
                            }
                            catch (SqlException ex)
                            {
                                _logger.LogError("SQL");
                            }
                        }
                    }
                }
            }
            return (-1);
        }

        /// <summary>
        /// Get the list of ServicedLocations
        /// </summary>
        /// <returns>List of ServicedLocation records</returns>
        public async Task<IReadOnlyList<HspnServicedLocation>> GetServicedLocationsAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServicedLocation>)await connection.QueryAsync<HspnServicedLocation>(HspnQueries.GetServicedLocations);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ServicedLocation by ServicedLocationId
        /// </summary>
        /// <returns>Single ServicedLocation record</returns>
        public async Task<IReadOnlyList<HspnServicedLocation>> GetServicedLocationByIdAsync(int servicedLocationId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServicedLocation>)await connection.QueryAsync<HspnServicedLocation>(HspnQueries.GetServicedLocationById, new { ServicedLocationID = servicedLocationId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Insert ServicedItems
        /// </summary>
        /// <returns>ServicedItems to insert</returns>
        public async Task<int> InsertServicedLocationsAsync(List<HspnServicedLocation> servicedLocations)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    if (servicedLocations.Count > 0)
                    {
                        using (SqlCommand command = new SqlCommand("[hspn].[usp_UpsertServicedLocations]", (SqlConnection)connection))
                        {
                            await Task.Delay(1);
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramHoursOfOperationJSON = new SqlParameter();
                            SqlParameter paramServiceProviderId = new SqlParameter();
                            paramServiceProviderId.ParameterName = "@int_ServiceProviderID";
                            paramServiceProviderId.SqlDbType = SqlDbType.Int;
                            paramServiceProviderId.Value = servicedLocations[0].ServiceProviderID;
                            paramServiceProviderId.Direction = ParameterDirection.Input;
                            command.Parameters.Add(paramServiceProviderId);

                            SqlParameter paramStateCode = new SqlParameter();
                            paramStateCode.ParameterName = "@chr_StateCode";
                            paramStateCode.SqlDbType = SqlDbType.Char;
                            paramStateCode.Size = 2;
                            paramStateCode.Direction = ParameterDirection.Input;
                            paramStateCode.Value = servicedLocations[0].StateCode;
                            command.Parameters.Add(paramStateCode);

                            SqlParameter paramZipCSV = new SqlParameter();
                            paramZipCSV.ParameterName = "@vch_ZipCSV";
                            paramZipCSV.SqlDbType = SqlDbType.NVarChar;
                            paramZipCSV.Size = 10000;
                            paramZipCSV.Direction = ParameterDirection.Input;
                            paramZipCSV.Value = servicedLocations[0].ZipCSV;
                            command.Parameters.Add(paramZipCSV);

                            SqlParameter paramCityIDCSV = new SqlParameter();
                            paramCityIDCSV.ParameterName = "@vch_CityIDCSV";
                            paramCityIDCSV.SqlDbType = SqlDbType.NVarChar;
                            paramCityIDCSV.Size = 10000;
                            paramCityIDCSV.Direction = ParameterDirection.Input;
                            paramCityIDCSV.Value = servicedLocations[0].CityIDCSV;
                            command.Parameters.Add(paramCityIDCSV);

                            SqlParameter paramCountyFIPSCSV = new SqlParameter();
                            paramCountyFIPSCSV.ParameterName = "@vch_CountyFIPSCSV";
                            paramCountyFIPSCSV.SqlDbType = SqlDbType.NVarChar;
                            paramCountyFIPSCSV.Size = 10000;
                            paramCountyFIPSCSV.Direction = ParameterDirection.Input;
                            paramCountyFIPSCSV.Value = servicedLocations[0].CountyFIPSCSV;
                            command.Parameters.Add(paramCountyFIPSCSV);

                            SqlParameter paramCreatedBy = new SqlParameter();
                            paramCreatedBy.ParameterName = "@vch_CreatedBy";
                            paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                            paramCreatedBy.Size = 50;
                            paramCreatedBy.Direction = ParameterDirection.Input;
                            paramCreatedBy.Value = Environment.UserName;
                            command.Parameters.Add(paramCreatedBy);

                            SqlParameter paramErrorCode = new SqlParameter();
                            paramErrorCode.ParameterName = "@int_ErrorCode";
                            paramErrorCode.SqlDbType = SqlDbType.Int;
                            paramErrorCode.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorCode);

                            SqlParameter paramErrorMessage = new SqlParameter();
                            paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                            paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                            paramErrorMessage.Size = 500;
                            paramErrorMessage.Direction = ParameterDirection.Output;
                            command.Parameters.Add(paramErrorMessage);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                                if (errorCode == 0)
                                {
                                    return errorCode;
                                }
                                else
                                {
                                    string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                    _logger.LogError($"Stored Procedure [hspn].[usp_UpsertServicedItems] returned error: {errorCode} : {errorMessage}");
                                    return errorCode;
                                }
                            }
                            catch (SqlException ex)
                            {
                                _logger.LogError("SQL");
                            }
                        }
                    }
                }
            }
            return (-1);
        }

        /// <summary>
        /// Get the list of ServiceProviders
        /// </summary>
        /// <returns>List of ServiceProvider records</returns>
        public async Task<IReadOnlyList<HspnServiceProvider>> GetServiceProvidersAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceProvider>)await connection.QueryAsync<HspnServiceProvider>(HspnQueries.GetServiceProviders);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ServiceProvider by ServiceProviderId
        /// </summary>
        /// <returns>Single ServiceProvider record</returns>
        public async Task<IReadOnlyList<HspnServiceProvider>> GetServiceProviderByIdAsync(int serviceProviderId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnServiceProvider>)await connection.QueryAsync<HspnServiceProvider>(HspnQueries.GetServiceProviderById, new { ServiceProviderID = serviceProviderId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }


        public async Task<int> DeleteServiceProviderAsync(int serviceProviderId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand("[hspn].[usp_DeleteServiceProvider]", (SqlConnection)connection))
                    {
                        await Task.Delay(1);
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramHoursOfOperationJSON = new SqlParameter();
                        SqlParameter paramServiceProviderId = new SqlParameter();
                        paramServiceProviderId.ParameterName = "@int_ServiceProviderID";
                        paramServiceProviderId.SqlDbType = SqlDbType.Int;
                        paramServiceProviderId.Value = serviceProviderId;
                        paramServiceProviderId.Direction = ParameterDirection.Input;
                        command.Parameters.Add(paramServiceProviderId);

                        SqlParameter paramCreatedBy = new SqlParameter();
                        paramCreatedBy.ParameterName = "@vch_DeletedBy";
                        paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                        paramCreatedBy.Size = 50;
                        paramCreatedBy.Direction = ParameterDirection.Input;
                        paramCreatedBy.Value = Environment.UserName;
                        command.Parameters.Add(paramCreatedBy);

                        SqlParameter paramErrorCode = new SqlParameter();
                        paramErrorCode.ParameterName = "@int_ErrorCode";
                        paramErrorCode.SqlDbType = SqlDbType.Int;
                        paramErrorCode.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramErrorCode);

                        SqlParameter paramErrorMessage = new SqlParameter();
                        paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                        paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                        paramErrorMessage.Size = 500;
                        paramErrorMessage.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramErrorMessage);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                            if (errorCode == 0)
                            {
                                return errorCode;
                            }
                            else
                            {
                                string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                _logger.LogError($"Stored Procedure [hspn].[usp_UpsertCoupons] returned error: {errorCode} : {errorMessage}");
                                return errorCode;
                            }
                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError("SQL Exception:", ex);
                            throw;
                        }
                    }
                }
            }
        }

        public async Task<IReadOnlyList<HspnServiceProviderInfo>> GetServiceProviderInfoAsync(int serviceProviderId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                try
                {
                    using (connection)
                    {
                        using (SqlCommand command = new SqlCommand("[hspn].[usp_GetServiceProviderInfo]", (SqlConnection)connection))
                        {
                            await Task.Delay(1);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@int_ServiceProviderID", serviceProviderId));
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                List<HspnServiceProviderInfo> serviceProviderInfo = new List<HspnServiceProviderInfo>();
                                while (reader.Read())
                                {
                                    serviceProviderInfo.Add(new HspnServiceProviderInfo
                                    {
                                        ServiceProviderID = reader.GetInt32("ServiceProviderID"),
                                        ServiceProviderName = reader.GetString("ServiceProviderName"),
                                        NetworkStatusID = reader.GetInt32("NetworkStatusID"),
                                        FormTypeID = reader.IsDBNull("FormTypeID") ? null : reader.GetInt32("FormTypeID"),
                                        Phone = reader.GetString("Phone"),
                                        Email = reader.IsDBNull("Email") ? null : reader.GetString("Email"),
                                        ShopTypeID = reader.GetInt32("ShopTypeID"),
                                        ContactName = reader.GetString("ContactName"),
                                        StreetAddress = reader.GetString("StreetAddress"),
                                        City = reader.GetString("City"),
                                        StateCode = reader.GetString("StateCode"),
                                        Zip = reader.GetString("Zip"),
                                        CountryCode = reader.GetString("CountryCode"),
                                        ShowLocationOnSearches = reader.GetBoolean("ShowLocationOnSearches"),
                                        NumberOfTechnicians = reader.IsDBNull("NumberOfTechnicians") ? null : reader.GetInt32("NumberOfTechnicians"),
                                        MinimumInspectionRateInUSD = reader.IsDBNull("MinimumInspectionRateInUSD") ? null : reader.GetDecimal("MinimumInspectionRateInUSD"),
                                        OtherInfoJSON = reader.IsDBNull("OtherInfoJSON") ? null : reader.GetString("OtherInfoJSON"),
                                        //RecordStatus = reader.GetString("RecordStatus"),
                                        InsertDate = reader.GetString("InsertDate"),
                                        InsertedBy = reader.IsDBNull("InsertedBy") ? null : reader.GetString("InsertedBy"),
                                        ModifiedDate = reader.GetString("ModifiedDate"),
                                        ModifiedBy = reader.IsDBNull("ModifiedBy") ? null : reader.GetString("ModifiedBy"),
                                        NetworkStatus = reader.GetString("NetworkStatus"),
                                        NetworkStatusDescription = reader.IsDBNull("NetworkStatusDescription") ? null : reader.GetString("NetworkStatusDescription"),
                                        ShopType = reader.GetString("ShopType"),
                                        FormType = reader.IsDBNull("FormType") ? null : reader.GetString("FormType")
                                    });
                                }
                                return serviceProviderInfo;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        public async Task<int> InsertServiceProviderAsync(HspnServiceProviderModel serviceProviderInsert)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand("[hspn].[usp_InsertServiceProvider]", (SqlConnection)connection))
                    {
                        await Task.Delay(1);
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramServiceProvicerJSON = new SqlParameter();
                        paramServiceProvicerJSON.ParameterName = "@nvch_ServiceProviderJSON";
                        paramServiceProvicerJSON.SqlDbType = SqlDbType.NVarChar;
                        paramServiceProvicerJSON.Size = 10000;
                        paramServiceProvicerJSON.Direction = ParameterDirection.Input;
                        paramServiceProvicerJSON.Value = JsonSerializer.Serialize(serviceProviderInsert.ServiceProvider);
                        command.Parameters.Add(paramServiceProvicerJSON);

                        SqlParameter paramCouponJSON = new SqlParameter();
                        paramCouponJSON.ParameterName = "@nvch_CouponJSON";
                        paramCouponJSON.SqlDbType = SqlDbType.NVarChar;
                        paramCouponJSON.Size = 10000;
                        paramCouponJSON.Direction = ParameterDirection.Input;
                        paramCouponJSON.Value = JsonSerializer.Serialize(serviceProviderInsert.Coupons);
                        command.Parameters.Add(paramCouponJSON);

                        SqlParameter paramHourOfOperationJSON = new SqlParameter();
                        paramHourOfOperationJSON.ParameterName = "@nvch_HourOfOperationJSON";
                        paramHourOfOperationJSON.SqlDbType = SqlDbType.NVarChar;
                        paramHourOfOperationJSON.Size = 10000;
                        paramHourOfOperationJSON.Direction = ParameterDirection.Input;
                        paramHourOfOperationJSON.Value = JsonSerializer.Serialize(serviceProviderInsert.HoursOfOperation);
                        command.Parameters.Add(paramHourOfOperationJSON);

                        SqlParameter paramCreatedBy = new SqlParameter();
                        paramCreatedBy.ParameterName = "@vch_CreatedBy";
                        paramCreatedBy.SqlDbType = SqlDbType.NVarChar;
                        paramCreatedBy.Size = 50;
                        paramCreatedBy.Direction = ParameterDirection.Input;
                        paramCreatedBy.Value = Environment.UserName;
                        command.Parameters.Add(paramCreatedBy);

                        SqlParameter paramNewId = new SqlParameter();
                        paramNewId.ParameterName = "@int_NewID";
                        paramNewId.SqlDbType = SqlDbType.Int;
                        paramNewId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramNewId);

                        SqlParameter paramErrorCode = new SqlParameter();
                        paramErrorCode.ParameterName = "@int_ErrorCode";
                        paramErrorCode.SqlDbType = SqlDbType.Int;
                        paramErrorCode.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramErrorCode);

                        SqlParameter paramErrorMessage = new SqlParameter();
                        paramErrorMessage.ParameterName = "@vch_ErrorMessage";
                        paramErrorMessage.SqlDbType = SqlDbType.NVarChar;
                        paramErrorMessage.Size = 1000;
                        paramErrorMessage.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paramErrorMessage);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            int errorCode = (int)command.Parameters["@int_ErrorCode"].Value;
                            if (errorCode == 0)
                            {
                                int newId = (int)command.Parameters["@int_NewID"].Value;
                                return newId;
                            }
                            else
                            {
                                string errorMessage = (string)command.Parameters["@vch_ErrorMessage"].Value;
                                _logger.LogError($"Stored Procedure usp_InsertServiceProvider returned error: {errorCode} : {errorMessage}");
                                return errorCode;
                            }
                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError("SQL Exception:", ex);
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of ShopTypes
        /// </summary>
        /// <returns>List of ShopType records</returns>
        public async Task<IReadOnlyList<HspnShopType>> GetShopTypesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnShopType>)await connection.QueryAsync<HspnShopType>(HspnQueries.GetShopTypes);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get ShopType by ShopTypeId
        /// </summary>
        /// <returns>Single ShopType record</returns>
        public async Task<IReadOnlyList<HspnShopType>> GetShopTypeByIdAsync(int shopTypeId)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnShopType>)await connection.QueryAsync<HspnShopType>(HspnQueries.GetShopTypeById, new { ShopTypeID = shopTypeId });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of States
        /// </summary>
        /// <returns>List of State records</returns>
        public async Task<IReadOnlyList<HspnState>> GetStatesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnState>)await connection.QueryAsync<HspnState>(HspnQueries.GetStates);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get State by StateCode
        /// </summary>
        /// <returns>Single State record</returns>
        public async Task<IReadOnlyList<HspnState>> GetStateByCodeAsync(string stateCode)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnState>)await connection.QueryAsync<HspnState>(HspnQueries.GetStateByCode, new { StateCode = stateCode });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get the list of Zips
        /// </summary>
        /// <returns>List of Zip records</returns>
        public async Task<IReadOnlyList<HspnZip>> GetZipCodesAsync()
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnZip>)await connection.QueryAsync<HspnZip>(HspnQueries.GetZipCodes);
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Get Zip by StateCode
        /// </summary>
        /// <returns>Single Zip record</returns>
        public async Task<IReadOnlyList<HspnZip>> GetZipCodesByStateCodeAsync(string stateCode)
        {
            using (IDbConnection connection = _hspnContext.CreateHspnConnection())
            {
                connection.Open();
                try
                {
                    return (IReadOnlyList<HspnZip>)await connection.QueryAsync<HspnZip>(HspnQueries.GetZipCodesByStateCode, new { StateCode = stateCode });
                }
                catch (SqlException ex)
                {
                    _logger.LogError("SQL Exception:", ex);
                    throw;
                }
            }
        }

        #endregion
    }
}