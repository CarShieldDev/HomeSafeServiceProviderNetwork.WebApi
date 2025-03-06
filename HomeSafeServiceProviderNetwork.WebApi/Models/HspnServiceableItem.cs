namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServiceableItem
    {
        public int ServiceableItemID { get; set; }
        public string ServiceableItem { get; set; }
        public int ServiceableItemTypeID { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
