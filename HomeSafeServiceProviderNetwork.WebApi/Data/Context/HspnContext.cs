using HomeSafeServiceProviderNetwork.WebApi.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace HomeSafeServiceProviderNetwork.WebApi.Data.Context
{
    public class HspnContext
    {
        private ConnectionStringOptions connectionStringOptions;

        public HspnContext(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            connectionStringOptions = optionsMonitor.CurrentValue;
        }
        public IDbConnection CreateHspnConnection() => new SqlConnection(connectionStringOptions.HomeSafeServiceProviderNetwork);
    }
}
