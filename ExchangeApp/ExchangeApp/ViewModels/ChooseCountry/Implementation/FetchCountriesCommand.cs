using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.Core;
using ExchangeApp.Core.Api;
using ExchangeApp.ViewModels.Base.Implementation;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    internal class FetchCountriesCommand : AsyncCommand
    {
        private readonly IApiService _apiService;
        private readonly ChooseCountryViewModel _viewModel;

        public FetchCountriesCommand(IApiService apiService, ChooseCountryViewModel viewModel)
        {
            _viewModel = viewModel;
            _apiService = apiService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            //var result = await _apiService.FetchCurrenciesAsync(token);
            await Task.Delay(1000);
            var result = new List<Currency>
            {
              new Currency()
              {
                  CurrencyString = "CAD",
                  Value = 357
              },
              new Currency()
              {
                  CurrencyString = "GBP",
                  Value = 629
              },
              new Currency()
              {
                  CurrencyString = "CHF",
                  Value = 478
              },
              new Currency()
              {
                  CurrencyString = "USD",
                  Value = 476
              },
              new Currency()
              {
                  CurrencyString = "RUB",
                  Value = 7.54
              },
            };
            _viewModel.Countries = new ObservableCollection<CountryViewModel>(result.Select(
                item => new CountryViewModel
                {
                    Name = item.CurrencyString,
                    Rate = item.Value,
                    FlagPath = $"resource://ExchangeApp.Resources.Images.flag{item.CurrencyString}.png"
                }));

            return true;
        }
    }
}