namespace JC_PARK.Infra.Data.Provider
{
    public class ConfiguracaoProvider : System.Data.Entity.DbConfiguration
    {
        public ConfiguracaoProvider()
        {

            SetProviderServices(
                           System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName,
                           System.Data.Entity.SqlServer.SqlProviderServices.Instance
                           );
        }
    }
}
