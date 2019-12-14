using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Navigation;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    internal class ChooseFromCountryCommand : AsyncCommand
    {
        private readonly INavigationService _navigationService;
        private MainViewModel _viewModel;

        public ChooseFromCountryCommand(MainViewModel viewModel,
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            await _navigationService.NavigateAsync(PageMappings.ChooseCountriesPage, null);
            return true;
        }
    }
}