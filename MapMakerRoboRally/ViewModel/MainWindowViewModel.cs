using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using ZimLabs.WpfBase.NetCore;

namespace MapMakerRoboRally.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private CustomObservableObject _control;

        public CustomObservableObject Control
        {
            get => _control;
            set => SetField(ref _control, value);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MainWindowViewModel"/>
        /// </summary>
        public MainWindowViewModel()
        {
            ChangeControl(new MapMakerMainViewViewModel(this));
        }

        public ICommand AddMapTilesCommand => new DelegateCommand(() =>
        {
            var dialog = new OpenFileDialog { Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
                                                       "|PNG Portable Network Graphics (*.png)|*.png" +
                                                       "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
                                                       "|BMP Windows Bitmap (*.bmp)|*.bmp" +
                                                       "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
                                                       "|GIF Graphics Interchange Format (*.gif)|*.gif",
                Multiselect = true
            };

            if (dialog.ShowDialog() == true)
            {
                //Creates only if exists
                Directory.CreateDirectory("mapTiles");

                foreach (var dialogFileName in dialog.FileNames)
                {
                    File.Copy(dialogFileName, Path.Combine("mapTiles", dialogFileName.Split("\\").Last()), true);
                }

                if (Control is MapMakerMainViewViewModel vm)
                {
                    vm.NavMenu.ScanForMapTiles();
                }
            }
        });

        /// <summary>
        /// Changes the user control displayed in the main window
        /// </summary>
        public void ChangeControl<T>() where T : CustomObservableObject
        {
            Control = (CustomObservableObject)Activator.CreateInstance(typeof(T), this)! ?? throw new InvalidOperationException();

            if (Control is MapMakerMainViewViewModel vm)
            {
                vm.NavMenu.ScanForMapTiles();
            }
        }

        /// <summary>
        /// Changes the user control displayed in the main window
        /// </summary>
        public void ChangeControl(CustomObservableObject control)
        {
            Control = control;

            if (Control is MapMakerMainViewViewModel vm)
            {
                vm.NavMenu.ScanForMapTiles();
            }
        }
    }
}
