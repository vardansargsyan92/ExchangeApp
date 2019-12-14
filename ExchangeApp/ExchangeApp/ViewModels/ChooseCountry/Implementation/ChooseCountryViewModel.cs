﻿using System.Collections.Generic;
using ExchangeApp.ViewModels.Base;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Navigation;
using PropertyChanged;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class ChooseCountryViewModel : BaseNavigationViewModel, IChooseCountryViewModel
    {
        public ChooseCountryViewModel()
        {
            FetchCountriesCommand = new FetchCountriesCommand(this);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            FetchCountriesCommand.ExecuteAsync(null);
        }

        public IAsyncCommand FetchCountriesCommand { get; }
        public IList<CountryViewModel> Countries { get; }
    }
}