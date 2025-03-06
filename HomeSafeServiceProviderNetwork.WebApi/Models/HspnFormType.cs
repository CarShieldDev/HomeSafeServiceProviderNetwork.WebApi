namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnFormType
    {
        public int FormTypeID { get; set; }
        public string FormType { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
