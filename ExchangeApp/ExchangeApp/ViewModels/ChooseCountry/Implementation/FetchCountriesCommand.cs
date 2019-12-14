using System;
using System.Threading;
using System.Threading.Tasks;
using ExchangeApp.ViewModels.Base.Implementation;

namespace ExchangeApp.ViewModels.ChooseCountry.Implementation
{
    internal class FetchCountriesCommand : AsyncCommand
    {
        public FetchCountriesCommand(ChooseCountryViewModel viewModel)
        {
        }

        protected override async  Task<bool> ExecuteCoreAsync(object parameter, CancellationToken token = default)
        {
            return true;
        }
    }
}