using System.ComponentModel;
using System.Globalization;
using ExchangeApp.ViewModels.Base;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Navigation;
using Prism.Services;
using PropertyChanged;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class MainViewModel : BaseNavigationViewModel, IMainViewModel
    {
        public MainViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            InDemoVersionCommand = new InDemoVersionCommand(dialogService);
            ChooseFromCountryCommand = new ChooseFromCountryCommand(this, navigationService);
            ConfirmCommand= new ConfirmCommand(dialogService);
            DeclineCommand = new DeclineCommand(dialogService);
            PropertyChanged += OnInputCurrencyChanged;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            var navParams = (CountryViewModelNavigation) parameters[nameof(CountryViewModelNavigation)];
            if (navParams != null)
            {
                ResultCurrencyFlag = navParams.FlagPath;
                ResultCurrencyName = navParams.Name;
                ResultCurrencyValue = navParams.Rate;
                ResultAmount = navParams.Rate.ToString(CultureInfo.InvariantCulture);
                ChangeCurrencyResult();
            }

            
        }

        public IAsyncCommand ChooseFromCountryCommand { get; }
        public IAsyncCommand InDemoVersionCommand { get; }
        public IAsyncCommand ConfirmCommand { get; }
        public IAsyncCommand DeclineCommand { get; }
        public string InputAmount { get; set; } = "1";
        public string ResultAmount { get; internal set; } = "476";

        public string ResultCurrencyFlag { get; internal set; } =
            "resource://ExchangeApp.Resources.Images.flagUSD.png";

        public double ResultCurrencyValue { get; internal set; } = 476;
        public string ResultCurrencyName { get; internal set; } = "USD";

        private void OnInputCurrencyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(InputAmount)) ChangeCurrencyResult();
        }

        private void ChangeCurrencyResult()
        {
            if (!string.IsNullOrEmpty(InputAmount))
            {
                var input = double.Parse(InputAmount, CultureInfo.InvariantCulture);
                var rate = 1 / ResultCurrencyValue;
                ResultAmount = (input * rate).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}