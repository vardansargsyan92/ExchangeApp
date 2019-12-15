using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;
using ExchangeApp.ViewModels.Main;
using Prism.Navigation;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    internal class SelectCurrencyCommand : AsyncCommand
    {
        private readonly INavigationService _navigationService;
        private ChooseCountryViewModel _viewModel;

        public SelectCurrencyCommand(ChooseCountryViewModel viewModel, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            if (parameter is CountryViewModel currency)
            {
                var navParams = new NavigationParameters
                {
                    {
                        nameof(CountryViewModelNavigation),
                        new CountryViewModelNavigation(currency.Name, currency.Rate, currency.FlagPath)
                    }
                };
                await _navigationService.GoBackAsync(navParams);
                return true;
            }


            return false;
        }
    }
}