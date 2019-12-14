using System.Diagnostics;
using Prism.Navigation;

namespace ExchangeApp.ViewModels.Base.Implementation
{
    public class BaseNavigationViewModel : BaseBindableObject, INavigationViewModel
    {
        protected BaseNavigationViewModel()
        {
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
           // Debug.WriteLine("Navigated from {ViewModel} with parameters {@Parameters}", GetType().Name, parameters);
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
           // Debug.WriteLine("Navigated to {ViewModel} with parameters {@Parameters}", GetType().Name, parameters);
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            //Debug.WriteLine("Navigating to {ViewModel} with parameters {@Parameters}", GetType().Name, parameters);
        }
    }
}