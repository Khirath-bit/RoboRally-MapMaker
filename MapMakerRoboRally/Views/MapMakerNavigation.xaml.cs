using MapMakerRoboRally.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapMakerRoboRally.Views
{
    /// <summary>
    /// Interaction logic for MapMakerNavigation.xaml
    /// </summary>
    public partial class MapMakerNavigation : UserControl
    {
        public MapMakerNavigation()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is MapMakerNavigationViewModel vm)
                vm.Filter(FilterTextBox.Text);
        }
    }
}
