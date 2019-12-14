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
        }

        public IAsyncCommand ChooseFromCountryCommand { get; }
        public string InputAmount { get; set; } = "0";
    }
}