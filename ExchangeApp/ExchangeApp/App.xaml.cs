using ExchangeApp.Pages;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace ExchangeApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var container = containerRegistry.GetContainer();

            containerRegistry.RegisterAppDependencies();


            ServiceLocator.Container = container;
        }

        protected override void OnInitialized()
        {
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnResume()
        {
        }
    }
}