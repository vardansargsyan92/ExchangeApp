namespace ExchangeApp.Core.Api.Implementation
{
    public class DevelopmentConfigurationProvider : IConfigurationProvider
    {
        public string BaseAddress => "http://51.15.70.207:5000/api/";
    }
}