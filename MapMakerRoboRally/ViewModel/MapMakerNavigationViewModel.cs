using MahApps.Metro.Controls;
using MapMakerRoboRally.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using ZimLabs.WpfBase.NetCore;

namespace MapMakerRoboRally.ViewModel
{
    public class MapMakerNavigationViewModel : ObservableObject
    {
        private ObservableCollection<MapTileEntry> _mapTiles = new ();

        public ObservableCollection<MapTileEntry> MapTiles
        {
            get => _mapTiles;
            set => SetField(ref _mapTiles, value);
        }

        private List<MapTileEntry> _totalMapTiles = new ();

        public MapMakerNavigationViewModel() 
        {
            MapTiles.Add(new ());
        }

        public void ScanForMapTiles()
        {
            MapTiles.Clear();
            _totalMapTiles.Clear();

            foreach (var file in Directory.GetFiles("mapTiles"))
            {
                MapTiles.Add(new MapTileEntry(file.Split(".").First().Split("\\").Last(), file));
            }

            _totalMapTiles = MapTiles.ToList();
        }

        public void Filter(string filter)
        {
            MapTiles.Clear();

            foreach (var tile in _totalMapTiles)
            {
                if(tile.TextPart.Text.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    MapTiles.Add(tile);
            }
        }
    }
}
