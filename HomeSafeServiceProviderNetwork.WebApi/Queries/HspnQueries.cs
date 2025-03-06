using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace HomeSafeServiceProviderNetwork.WebApi.Queries
{
    [ExcludeFromCodeCoverage]
    public static class HspnQueries
    {
        public static string GetBrandBase =>
            @"SELECT [BrandID],
                     [Brand],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[Brand]
               WHERE [RecordStatus] = 'A'";

        public static string GetBrands =>
            GetBrandBase;

        public static string GetBrandById =>
            GetBrandBase + @"
                 AND [BrandID] = @BrandID";

        public static string GetCityBase =>
            @"SELECT [CityID],
                     [StateCode],
                     [CityName],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[City]
               WHERE [RecordStatus] = 'A'";

        public static string GetCities =>
            GetCityBase + @"
                 AND [StateCode] = @StateCode";

        public static string GetCityById =>
            GetCityBase + @"
                 AND [CityID] = @CityID";

        public static string GetCountyBase =>
            @"SELECT [CountyFIPS],
                     [StateCode],
                     [CountyName],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[County]
               WHERE [RecordStatus] = 'A'";

        public static string GetCountiesByStateCode =>
            GetCountyBase + @"
                 AND [StateCode] = @StateCode";

        public static string GetCountyByFips =>
            GetCountyBase + @"
                 AND [CountyFIPS] = @CountyFIPS";

        public static string GetCouponBase =>
            @"SELECT [CouponID],
                     [Coupon],
                     [ServiceProviderID],
                     [Link],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[Coupon]
               WHERE [RecordStatus] = 'A'";

        public static string GetCoupons =>
            GetCouponBase;

        public static string GetCouponById =>
            GetCouponBase + @"
                 AND [CouponID] = @CouponID";

        public static string GetFormTypeBase =>
            @"SELECT [FormTypeID],
                     [FormType],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[FormType]
               WHERE [RecordStatus] = 'A'";

        public static string GetFormTypes =>
            GetFormTypeBase;

        public static string GetFormTypeById =>
            GetFormTypeBase + @"
                 AND [FormTypeID] = @FormTypeID";

        public static string GetFormTypesByType =>
            GetFormTypeBase + @"
                 AND [FormType] = @FormType";

        public static string GetHourOfOperationBase =>
            @"SELECT [HourOfOperationID],
                     [ServiceProviderID],
                     [DayNumberOfWeek],
                     [OpenTime],
                     [CloseTime],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[HourOfOperation]
               WHERE [RecordStatus] = 'A'";

        public static string GetHoursOfOperation =>
            GetHourOfOperationBase;

        public static string GetHourOfOperationById =>
            GetHourOfOperationBase + @"
                 AND [HourOfOperationID] = @HourOfOperationID";

        public static string GetNetworkStatusBase =>
            @"SELECT [NetworkStatusID],
                     [NetworkStatus],
                     [NetworkStatusDescription],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[NetworkStatus]
               WHERE [RecordStatus] = 'A'";

        public static string GetNetworkStatuses =>
            GetNetworkStatusBase;

        public static string GetNetworkStatusById =>
            GetNetworkStatusBase + @"
                 AND [NetworkStatusID] = @NetworkStatusID";

        public static string GetServiceableItemBase =>
            @"SELECT [ServiceableItemID],
                     [ServiceableItem],
                     [ServiceableItemTypeID],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ServiceableItem]
               WHERE [RecordStatus] = 'A'";

        public static string GetServiceableItems =>
            GetServiceableItemBase;

        public static string GetServiceableItemById =>
            GetServiceableItemBase + @"
                 AND [ServiceableItemID] = @ServiceableItemID";

        public static string GetServiceableItemTypeBase =>
            @"SELECT [ServiceableItemTypeID],
                     [ServiceableItemType],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ServiceableItemType]
               WHERE [RecordStatus] = 'A'";

        public static string GetServiceableItemTypes =>
            GetServiceableItemTypeBase;

        public static string GetServiceableItemTypeById =>
            GetServiceableItemTypeBase + @"
                 AND [ServiceableItemTypeID] = @ServiceableItemTypeID";

        public static string GetServicedItemBase =>
            @"SELECT [ServicedItemID],
                     [ServiceProviderID],
                     [ServiceableItemID],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ServicedItem]
               WHERE [RecordStatus] = 'A'";

        public static string GetServicedItems =>
            GetServicedItemBase;

        public static string GetServicedItemById =>
            GetServicedItemBase + @"
                 AND [ServicedItemID] = @ServicedItemID";

        public static string GetServicedLocationBase =>
            @"SELECT [ServicedLocationID],
                     [StateCode],
                     [ServiceProviderID],
                     [ZipCSV],
                     [CityIDCSV],
                     [CountyFIPSCSV],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ServicedLocation]
               WHERE [RecordStatus] = 'A'";

        public static string GetServicedLocations =>
            GetServicedLocationBase;

        public static string GetServicedLocationById =>
            GetServicedLocationBase + @"
                 AND [ServicedLocationID] = @ServicedLocationID";

        public static string GetServiceProviderBase =>
            @"SELECT [ServiceProviderID],
                     [ServiceProviderName],
                     [NetworkStatusID],
                     [FormTypeID],
                     [Phone],
                     [Email],
                     [ShopTypeID],
                     [ContactName],
                     [StreetAddress],
                     [City],
                     [StateCode],
                     [Zip],
                     [CountryCode],
                     [ShowLocationOnSearches],
                     [NumberOfTechnicians],
                     [MinimumInspectionRateInUSD],
                     [OtherInfoJSON],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ServiceProvider]
               WHERE [RecordStatus] = 'A'";

        public static string GetServiceProviders =>
            GetServiceProviderBase;

        public static string GetServiceProviderById =>
            GetServiceProviderBase + @"
                 AND [ServiceProviderID] = @ServiceProviderID";

        public static string GetShopTypeBase =>
            @"SELECT [ShopTypeID],
                     [ShopType],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[ShopType]
               WHERE [RecordStatus] = 'A'";

        public static string GetShopTypes =>
            GetShopTypeBase;

        public static string GetShopTypeById =>
            GetShopTypeBase + @"
                 AND [ShopTypeID] = @ShopTypeID";

        public static string GetStatesBase =>
            @"SELECT [StateCode],
                     [StateName],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[States]
               WHERE [RecordStatus] = 'A'";

        public static string GetStates =>
            GetStatesBase;

        public static string GetStateByCode =>
            GetStatesBase + @"
                 AND [StateCode] = @StateCode";

        public static string GetZipBase =>
            @"SELECT [ZipCode],
                     [StateCode],
                     [RecordStatus],
                     [InsertDate],
                     [InsertedBy],
                     [ModifiedDate],
                     [ModifiedBy]
                FROM [hspn].[Zip]
               WHERE [RecordStatus] = 'A'";

        public static string GetZipCodes =>
            GetZipBase;

        public static string GetZipCodesByStateCode =>
            GetZipBase + @"
                 AND [StateCode] = @StateCode";
    }
}
