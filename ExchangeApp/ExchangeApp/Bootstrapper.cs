using Prism.Ioc;
using Xamarin.Forms;

namespace ExchangeApp
{
    public static class Bootstrapper
    {
        public static IContainerRegistry RegisterAppDependencies(this IContainerRegistry container)
        {
            

            // Support pages
            container.RegisterForNavigation<NavigationPage>();


            return container;
        }
    }
}