using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace YLSaveFileEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GameData _selectedGameData = new GameData();
        public GameData SelectedGameData
        {
            get
            {
                SaveButton.IsEnabled = true;
                return _selectedGameData;
            }
            set
            {
                _selectedGameData = value;
                RaisePropertyChanged();
            }
        }
        public List<GameStat> GameStatsVertical { get; set; }
        public string SelectedFile { get; set; }
        public bool FileReadOnly { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _selectedGameData.Gamestats.Names.Length; i++)
            {
                _selectedGameData.Gamestats.Values[i] = GameStatsVertical[i].Value;
            }
            string selectedGameDataJSON = SelectedGameData.ToJson();
            File.WriteAllText(SelectedFile, selectedGameDataJSON);
            SaveButton.IsEnabled = false;
        }

        private void LoadButton_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\Program Files (x86)\Steam\userdata\144944088\360830\remote";
            SelectFile:
            if (openFileDialog.ShowDialog() == true)
            {
                if (!System.IO.Path.GetFileName(openFileDialog.FileName).StartsWith("slot"))
                {
                    MessageBox.Show("Must open \"slot#.dat\"", @"Can't Open File ¯\_(ツ)_/¯", MessageBoxButton.OK, MessageBoxImage.Error);
                    goto SelectFile;
                }
                SelectedFile = openFileDialog.FileName;
            }
            else return;

            SelectedGameData = new GameData();
            SelectedGameData = GameData.FromJson(File.ReadAllText(SelectedFile));
            
            //SaveButton.IsEnabled = false;
            //SelectedGameData.Gamestats.Names

            GameStatsVertical = new List<GameStat>();
            for (int i = 0; i < _selectedGameData.Gamestats.Names.Length; i++)
            {
                GameStatsVertical.Add(new GameStat(i+1, _selectedGameData.Gamestats.Names[i], _selectedGameData.Gamestats.Values[i]));
            }

            DataContext = null;
            DataContext = this;
            DataEditView.IsEnabled = true;
        }

        private void DataEditView_Updated(object sender, EventArgs e)
        {
            //SaveButton.IsEnabled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public class GameStat
        {
            public GameStat(int id, string name, int value)
            {
                Id = id;
                Name = name;
                Value = value;
            }
            public int Id { get; }
            public string Name { get; }
            public int Value { get; set; }
        }

    }
}
