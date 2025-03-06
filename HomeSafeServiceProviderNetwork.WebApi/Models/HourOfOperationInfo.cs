namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HourOfOperationInfo
    {
        public int ServiceProviderID { get; set; }
        public string Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }

    }
}
