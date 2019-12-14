using System.Collections.Generic;
using ExchangeApp.ViewModels.Base;
using ExchangeApp.ViewModels.Base.Implementation;
using PropertyChanged;

namespace ExchangeApp.ViewModels.ChooseCountry
{
    [AddINotifyPropertyChangedInterface]
    public class CountryViewModel : BaseBindableObject
    {
        public string Name { get; set; }

        public double Rate { get; set; }

        public string FlagPath { get; set; }
    }

    public interface IChooseCountryViewModel : INavigationViewModel
    {
        IAsyncCommand FetchCountriesCommand { get; }

        IList<CountryViewModel> Countries { get; }
    }
}