using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    public partial class MainWindow : Window
    {
        public GameData SelectedGameData { get; set; } = new GameData();
        public List<GameStat> GameStatsVertical { get; set; } = new List<GameStat>();
        public string SelectedFile { get; set; }
        public bool FileReadOnly { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            var attr = File.GetAttributes(SelectedFile);
            // unset read-only
            attr &= ~FileAttributes.ReadOnly;
            File.SetAttributes(SelectedFile, attr);

            for (int i = 0; i < SelectedGameData.Gamestats.Names.Length; i++)
            {
                SelectedGameData.Gamestats.Values[i] = GameStatsVertical[i].Value;
            }
            string selectedGameDataJSON = SelectedGameData.ToJson();
            File.WriteAllText(SelectedFile, selectedGameDataJSON);

            
            if (FileReadOnly)
            {
                // set read-only
                attr |= FileAttributes.ReadOnly;
                File.SetAttributes(SelectedFile, attr);
            }
            else
            {
                // unset read-only
                attr &= ~FileAttributes.ReadOnly;
                File.SetAttributes(SelectedFile, attr);
            }

            SaveButton.IsEnabled = false;
            DelayedSaveButtonEnable();
        }

        private async void DelayedSaveButtonEnable()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            SaveButton.IsEnabled = true;
        }

        private void LoadButton_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
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
            
            SaveButton.IsEnabled = true;
            //SelectedGameData.Gamestats.Names

            GameStatsVertical = new List<GameStat>();
            for (int i = 0; i < SelectedGameData.Gamestats.Names.Length; i++)
            {
                GameStatsVertical.Add(new GameStat(i+1, SelectedGameData.Gamestats.Names[i], SelectedGameData.Gamestats.Values[i]));
            }

            var attr = File.GetAttributes(SelectedFile);
            if (attr == (attr | FileAttributes.ReadOnly))
            {
                ReadOnlyCheckBox.IsChecked = true;
            }
            else if (attr == (attr & ~FileAttributes.ReadOnly))
            {
                ReadOnlyCheckBox.IsChecked = false;
            }
            ReadOnlyCheckBox.IsEnabled = true;

            DataContext = null;
            DataContext = this;
            DataEditView.IsEnabled = true;
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
