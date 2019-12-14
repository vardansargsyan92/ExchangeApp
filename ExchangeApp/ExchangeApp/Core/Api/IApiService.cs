using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeApp.Core.Api
{
    public interface IApiService
    {
        Task<List<Currency>> FetchCurrenciesAsync(CancellationToken token = default);
    }
}
