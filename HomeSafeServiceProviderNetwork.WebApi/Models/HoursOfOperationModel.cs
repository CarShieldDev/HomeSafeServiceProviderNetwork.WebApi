namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HoursOfOperationModel
    {
        public int ServiceProviderID { get; set; }
        public List<HourOfOperationInfo> HoursOfOperationInfo { get; set; }
    }
}
