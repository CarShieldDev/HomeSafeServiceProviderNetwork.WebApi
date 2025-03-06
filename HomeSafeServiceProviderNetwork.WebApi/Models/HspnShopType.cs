namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnShopType
    {
        public int ShopTypeID { get; set; }
        public string ShopType { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
