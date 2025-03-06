namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServicedLocation
    {
        public int ServicedLocationID { get; set; }
        public string StateCode { get; set; }
        public int ServiceProviderID { get; set; }
        public string ZipCSV { get; set; }
        public string CityIDCSV { get; set; }
        public string CountyFIPSCSV { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
