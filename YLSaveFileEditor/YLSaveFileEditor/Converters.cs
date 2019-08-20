using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace YLSaveFileEditor
{

    public class GameStatsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            Gamestats valueGameStats = (Gamestats)value;
            List<GameStatItem> gameStatItems = new List<GameStatItem>();
            for (int i = 0; i < valueGameStats.Names.Count(); i++)
            {
                GameStatItem gameStatItem = new GameStatItem() { Name = valueGameStats.Names[i], Value = valueGameStats.Values[i] };
                gameStatItems.Add(gameStatItem);
            }
            return gameStatItems;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private class GameStatItem
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }

    public class CurrentLoadStartPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == int.Parse((string)parameter))
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;
            if (!(bool)value)
                return Binding.DoNothing;
            return int.Parse((string)parameter);
        }
    }
}
    
