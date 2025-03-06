namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnCounty
    {
        public string CountyFIPS { get; set; }
        public string StateCode { get; set; }
        public string CountyName { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
