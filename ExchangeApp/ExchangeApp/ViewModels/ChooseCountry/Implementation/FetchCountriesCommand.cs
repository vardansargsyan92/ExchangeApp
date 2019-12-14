using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.Core.Api;
using ExchangeApp.ViewModels.Base.Implementation;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    internal class FetchCountriesCommand : AsyncCommand
    {
        private readonly IApiService _apiService;
        private ChooseCountryViewModel _viewModel;

        public FetchCountriesCommand(IApiService apiService, ChooseCountryViewModel viewModel)
        {
            _viewModel = viewModel;
            _apiService = apiService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            var result = await _apiService.FetchCurrenciesAsync(token);
            return true;
        }
    }
}