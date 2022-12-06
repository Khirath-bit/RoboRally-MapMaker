using MahApps.Metro.Controls;
using MapMakerRoboRally.ViewModel;
using System.Runtime.Intrinsics.X86;
using System.Windows;

namespace MapMakerRoboRally.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && viewModel.Control is MapMakerMainViewViewModel vm)
            {
                vm.ExportMap();
            }
        }

        private void ImportMapBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && viewModel.Control is MapMakerMainViewViewModel vm)
            {
                vm.ImportMap();
            }
        }
    }
}
