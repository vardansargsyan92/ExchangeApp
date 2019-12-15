using System.Linq;
using ExchangeApp.ViewModels.ChooseCountry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExchangeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseCountriesPage : ContentPage
    {
        private readonly IChooseCountryViewModel _viewModel;

        public ChooseCountriesPage()
        {
            InitializeComponent();
            _viewModel = (IChooseCountryViewModel) BindingContext;
        }

        private void OnCurrencySelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as CountryViewModel;
            _viewModel.SelectCurrencyCommand.ExecuteAsync(selectedItem);
        }
    }
}