using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExchangeApp.Core.Api;
using ExchangeApp.ViewModels.Base;
using ExchangeApp.ViewModels.Base.Implementation;
using FFImageLoading.Exceptions;
using Prism.Navigation;
using PropertyChanged;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class ChooseCountryViewModel : BaseNavigationViewModel, IChooseCountryViewModel
    {
        public ChooseCountryViewModel(IApiService apiService,INavigationService navigationService)
        {
            FetchCountriesCommand = new FetchCountriesCommand(apiService, this);
            SelectCurrencyCommand = new SelectCurrencyCommand(this, navigationService);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            FetchCountriesCommand.ExecuteAsync(null);
        }

        public IAsyncCommand FetchCountriesCommand { get; }
        public IAsyncCommand SelectCurrencyCommand { get; }
        public ObservableCollection<CountryViewModel> Countries { get; internal set; }
    }
}