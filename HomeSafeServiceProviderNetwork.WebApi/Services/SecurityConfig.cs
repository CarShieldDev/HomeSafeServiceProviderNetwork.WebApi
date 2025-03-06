using HomeSafeServiceProviderNetwork.WebApi.Interfaces.Config;

namespace HomeSafeServiceProviderNetwork.WebApi.Services
{
    public class SecurityConfig : ISecurityConfig
    {
        public const string ConfigSectionName = "Security";
        public List<string> AllowedUsers { get; set; }
    }
}
