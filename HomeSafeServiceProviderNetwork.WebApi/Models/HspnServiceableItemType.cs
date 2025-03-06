namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServiceableItemType
    {
        public int ServiceableItemTypeID { get; set; }
        public string ServiceableItemType { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
