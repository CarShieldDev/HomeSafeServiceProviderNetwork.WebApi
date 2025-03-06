namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServiceProviderModel
    {
        public HspnServiceProvider ServiceProvider { get; set; }
        public List<HspnCouponModel> Coupons { get; set; }
        public List<HspnHourOfOperationModel> HoursOfOperation { get; set; }
    }
}
