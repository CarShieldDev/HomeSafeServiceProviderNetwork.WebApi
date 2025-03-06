namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnNetworkStatus
    {
        public int NetworkStatusID { get; set; }
        public string NetworkStatus { get; set; }
        public string NetworkStatusDescription { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
