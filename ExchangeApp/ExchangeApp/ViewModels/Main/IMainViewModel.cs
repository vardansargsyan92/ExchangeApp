using ExchangeApp.ViewModels.Base;

namespace ExchangeApp.ViewModels.Main
{

    public class CountryViewModelNavigation
    {
        public CountryViewModelNavigation(string name, double rate, string flagPath)
        {
            Name = name;
            Rate = rate;
            FlagPath = flagPath;
        }

        public string Name { get; }

        public double Rate { get;}

        public string FlagPath { get;}
    }

    public interface IMainViewModel : INavigationViewModel
    {
        IAsyncCommand ChooseFromCountryCommand { get; }
        IAsyncCommand InDemoVersionCommand { get; }
        IAsyncCommand ConfirmCommand { get; }
        IAsyncCommand DeclineCommand { get; }
        string InputAmount { get; set; }
        string ResultAmount { get; }
        string ResultCurrencyFlag { get; }
        double ResultCurrencyValue { get; }
        string ResultCurrencyName { get; }
    }
}