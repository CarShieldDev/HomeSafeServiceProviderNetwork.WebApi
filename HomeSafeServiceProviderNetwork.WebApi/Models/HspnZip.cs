namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnZip
    {
        public string ZipCode { get; set; }
        public string StateCode { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
