using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSafeServiceProviderNetwork.WebApi.Models
{
    public class HspnServiceProvider
    {
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public int NetworkStatusID { get; set; }
        public int FormTypeID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ShopTypeID { get; set; }
        public string ContactName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public bool ShowLocationOnSearches { get; set; }
        public int NumberOfTechnicians { get; set; }
        public decimal MinimumInspectionRateInUSD { get; set; }
        public string OtherInfoJSON { get; set; }
        public char RecordStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
