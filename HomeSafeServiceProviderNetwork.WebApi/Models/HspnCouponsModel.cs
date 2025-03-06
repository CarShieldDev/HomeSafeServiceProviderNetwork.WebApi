namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnCouponsModel
    {
        public int ServiceProviderID { get; set; }
        public List<HspnCouponModel> Coupons { get; set; }
    }
}
