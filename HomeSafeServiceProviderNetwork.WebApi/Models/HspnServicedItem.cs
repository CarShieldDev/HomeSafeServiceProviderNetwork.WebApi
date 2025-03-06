namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServicedItem
    {
        public int ServicedItemID { get; set; }
        public int ServiceProviderID { get; set; }
        public int ServiceableItemID { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
