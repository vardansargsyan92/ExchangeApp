using ExchangeApp.ViewModels.Base;

namespace ExchangeApp.ViewModels.Main
{
    public interface IMainViewModel : INavigationViewModel
    {
        IAsyncCommand ChooseFromCountryCommand { get; }
        string InputAmount { get; set; }
        string ResultAmount { get; }
        string ResultCurrencyFlag { get; }
        double ResultCurrencyValue { get; }
        string ResultCurrencyName { get; }
    }
}