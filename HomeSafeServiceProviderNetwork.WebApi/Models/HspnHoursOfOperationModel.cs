namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnHoursOfOperationModel
    {
        public int ServiceProviderID { get; set; }
        public List<HspnHourOfOperationModel> HoursOfOperation { get; set; }

    }
}
