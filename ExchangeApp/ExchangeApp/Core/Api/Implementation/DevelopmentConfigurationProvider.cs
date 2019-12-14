namespace ExchangeApp.Core.Api.Implementation
{
    public class DevelopmentConfigurationProvider : IConfigurationProvider
    {
        public string BaseAddress => "http://192.168.43.189:9550/api/v1/converter/";
    }
}