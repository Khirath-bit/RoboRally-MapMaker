using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MapMakerRoboRally.Views
{
    /// <summary>
    /// Interaction logic for MapTileEntry.xaml
    /// </summary>
    public partial class MapTileEntry : UserControl
    {
        private readonly string _pathToImg;

        public MapTileEntry()
        {
            InitializeComponent();
        }

        public MapTileEntry(string label, string pathToImg)
        {
            _pathToImg = pathToImg;
            InitializeComponent();
            TextPart.Text = label;
            ImagePart.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + pathToImg));
        }

        private void MapTileEntry_OnMouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(this, _pathToImg, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void MapTileEntry_OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
    }
}
