namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnBrand
    {
        public int BrandID { get; set; }
        public string Brand { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
