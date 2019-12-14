using ExchangeApp.Pages;
using ExchangeApp.ViewModels.ChooseCountry;
using ExchangeApp.ViewModels.ChooseCountry.Implementation;
using ExchangeApp.ViewModels.Main;
using ExchangeApp.ViewModels.Main.Implementation;
using Prism.Ioc;
using Prism.Unity;
using Unity;
using Xamarin.Forms;

namespace ExchangeApp
{
    public static class Bootstrapper
    {
        public static IContainerRegistry RegisterAppDependencies(this IContainerRegistry containerRegistry)
        {
            var container = containerRegistry.GetContainer();

            //ViewModels
            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IChooseCountryViewModel, ChooseCountryViewModel>();

            // Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, IMainViewModel>();
            containerRegistry.RegisterForNavigation<ChooseCountriesPage, IChooseCountryViewModel>();

            return containerRegistry;
        }
    }
}