using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeApp.Core.Api.Implementation
{
    public class RestApiService : IApiService
    {
        private const string FetchCurrenciesPath = "amd";
        private readonly IDataClient _dataClient;

        public RestApiService(IDataClient dataClient)
        {
            _dataClient = dataClient;
        }

        public async Task<List<Currency>> FetchCurrenciesAsync(CancellationToken token = default)
        {
            try
            {
                var result =
                    await _dataClient.GetAsync<List<Currency>>(FetchCurrenciesPath, token);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}