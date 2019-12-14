using System.ComponentModel;
using Prism.Navigation;

namespace ExchangeApp.ViewModels.Base
{
    public interface INavigationViewModel : INotifyPropertyChanged, INavigationAware
    {
    }
}