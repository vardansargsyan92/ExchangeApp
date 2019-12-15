using System.Globalization;
using ExchangeApp.ViewModels.Base;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Navigation;
using PropertyChanged;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class MainViewModel : BaseNavigationViewModel, IMainViewModel
    {
        public MainViewModel(INavigationService navigationService)
        {
            ChooseFromCountryCommand = new ChooseFromCountryCommand(this, navigationService);
            this.PropertyChanged += OnInputCurrencyChanged;
        }

        private void OnInputCurrencyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(InputAmount))
            {
                if (!string.IsNullOrEmpty(InputAmount))
                {
                     var input= double.Parse(InputAmount, CultureInfo.InvariantCulture);
                     var rate = 1 / ResultCurrencyValue;
                     ResultAmount = (input * rate).ToString(CultureInfo.InvariantCulture);
                }


            }
        }

        public IAsyncCommand ChooseFromCountryCommand { get; }
        public string InputAmount { get; set; } = "1";
        public string ResultAmount { get; internal set; } = "476";

        public string ResultCurrencyFlag { get; internal set; } =
            "resource://ExchangeApp.Resources.Images.flagUSD.png";

        public double ResultCurrencyValue { get; internal set; } = 476;
        public string ResultCurrencyName { get; internal set; } = "USD";
    }
}