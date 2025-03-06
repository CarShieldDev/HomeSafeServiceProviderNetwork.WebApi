namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnHourOfOperation
    {
        string Day { get; set; }
        public int HourOfOperationID { get; set; }
        public int ServiceProviderID { get; set; }
        public int DayNumberOfWeek { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
