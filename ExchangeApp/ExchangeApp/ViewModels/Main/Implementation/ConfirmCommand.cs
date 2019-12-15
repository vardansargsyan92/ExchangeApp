using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Services;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    internal class ConfirmCommand : AsyncCommand
    {
        private readonly IPageDialogService _dialogService;

        public ConfirmCommand(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            await _dialogService.DisplayAlertAsync("Շնորհակալություն",
                "Գործարքը հաջողությամբ կատարված է։ Խնդրում ենք վերցնել անդորրագիրը։",
                "Լավ");
            return true;
        }
    }
}