using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSafeServiceProviderNetwork.WebApi.Interfaces.Config
{
    public interface ISecurityConfig
    {
        public static string ConfigSectionName { get; set; }
        public List<string> AllowedUsers { get; set; }
    }
}
