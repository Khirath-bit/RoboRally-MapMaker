using MahApps.Metro.Controls;
using System;
using System.Collections;
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
    /// Interaction logic for MapMakerMapGridView.xaml
    /// </summary>
    public partial class MapMakerMapGridView : UserControl
    {
        public MapMakerMapGridView()
        {
            InitializeComponent();

            for (int i = 0; i < 12; i++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                MainGrid.RowDefinitions.Add(new RowDefinition());
            }


            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var panel = new Rectangle();
                    SetEvents(panel);
                    panel.Tag = $"KEKW {i} {j}";
                    panel.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    panel.StrokeThickness = 0.3;
                    panel.Fill = new SolidColorBrush(Color.FromRgb(33,33,33));
                    Grid.SetRow(panel, i);
                    Grid.SetColumn(panel, j);
                    MainGrid.Children.Add(panel);
                }
            }
        }

        private void MapMakerMapGridView_OnDrop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            if (sender is Rectangle p)
            {
                //MessageBox.Show(p.Tag.ToString());
                var img = new Image();
                img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + (string)e.Data.GetData(typeof(string))));
                img.Stretch = Stretch.Fill;
                Grid.SetRow(img, Grid.GetRow(p));
                Grid.SetColumn(img, Grid.GetColumn(p));
                MainGrid.Children.Add(img);
            }

            e.Handled = true;
        }

        private void MapMakerMapGridView_OnDragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void MapMakerMapGridView_OnDragEnter(object sender, DragEventArgs e)
        {
            base.OnDragEnter(e);
            //Previous data saven 
        }

        private void MapMakerMapGridView_OnDragLeave(object sender, DragEventArgs e)
        {
            base.OnDragLeave(e);
            //undo shit if not dropped
        }

        private void SetEvents(Rectangle rect)
        {
            rect.Drop += MapMakerMapGridView_OnDrop;
            rect.DragOver += MapMakerMapGridView_OnDragOver;
            rect.DragEnter += MapMakerMapGridView_OnDragEnter;
            rect.DragLeave += MapMakerMapGridView_OnDragLeave;
        }
    }
}
