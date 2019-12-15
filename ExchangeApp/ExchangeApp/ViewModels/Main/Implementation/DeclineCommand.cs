using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Services;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    internal class DeclineCommand : AsyncCommand
    {
        private IPageDialogService _dialogService;

        public DeclineCommand(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            await _dialogService.DisplayAlertAsync("Ներողություն",
                "Գործարքը մերժված է։",
                "Լավ");
            return true;
        }
    }
}