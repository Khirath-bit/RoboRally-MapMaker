using MapMakerRoboRally.ViewModel;
using ZimLabs.WpfBase.NetCore;

namespace MapMakerRoboRally
{
    public abstract class CustomObservableObject : ObservableObject
    {
        protected readonly MainWindowViewModel MainViewModel;

        /// <summary>
        /// Creates a new instance of <see cref="CustomObservableObject"/>
        /// </summary>
        /// <param name="mainViewModel">Main view model to change the control</param>
        protected CustomObservableObject(MainWindowViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
    }
}
