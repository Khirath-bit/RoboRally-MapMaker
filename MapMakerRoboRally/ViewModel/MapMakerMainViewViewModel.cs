using Microsoft.Win32;
using System.Windows;
using ZimLabs.WpfBase.NetCore;

namespace MapMakerRoboRally.ViewModel
{
    public class MapMakerMainViewViewModel : CustomObservableObject
    {
        private MapMakerNavigationViewModel _navMenu;
        public MapMakerNavigationViewModel NavMenu
        {
            get => _navMenu;
            set => SetField(ref _navMenu, value);
        }

        private ObservableObject _mapGrid;
        public ObservableObject MapGrid
        {
            get => _mapGrid;
            set => SetField(ref _mapGrid, value);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MapMakerMainViewViewModel"/>
        /// </summary>
        /// <param name="mainViewModel">Main view model to change view later</param>
        public MapMakerMainViewViewModel(MainWindowViewModel mainViewModel) : base(mainViewModel)
        {
            NavMenu = new MapMakerNavigationViewModel();
            MapGrid = new MapMakerMapGridViewViewModel();
        }

        /// <summary>
        /// Exports the map as json file
        /// </summary>
        public void ExportMap()
        {
            var dialog = new SaveFileDialog { FileName = "MyMap", Filter = "JSON File (*.json)|*.json" };

            if (dialog.ShowDialog() == true)
            {

            }
        }

        /// <summary>
        /// Imports a new map
        /// </summary>
        public void ImportMap()
        {
            var dialog = new OpenFileDialog { FileName = "MyMap", Filter = "JSON File (*.json)|*.json" };

            if (dialog.ShowDialog() == true)
            {
                
            }
        }
    }
}
