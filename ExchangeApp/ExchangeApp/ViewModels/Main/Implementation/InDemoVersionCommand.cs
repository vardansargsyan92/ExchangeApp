using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;
using Prism.Services;

namespace ExchangeApp.ViewModels.Main.Implementation
{
    internal class InDemoVersionCommand : AsyncCommand
    {
        private readonly IPageDialogService _dialogService;

        public InDemoVersionCommand(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            await _dialogService.DisplayAlertAsync("Ուշադրություն", "Տվյալ գործարքները ժամանակավորապես հասանելի չէն։",
                "Լավ");
            return true;
        }
    }
}