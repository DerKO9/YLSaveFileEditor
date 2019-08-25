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
        public GameStatsListCollectionViews FilteredGameStats { get; set; }
        public string SelectedFile { get; set; } = "";
        public string SelectedFileDisplay { get => SelectedFile.Split('\\').LastOrDefault(); }
        public bool FileReadOnly { get; set; } = false;
        private OldWindowState OldWindowState { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            SaveFile();

            DelayedButtonEnable(e.OriginalSource as Button);
        }

        private void SaveFile()
        {
            var attr = File.GetAttributes(SelectedFile);
            // unset read-only
            attr &= ~FileAttributes.ReadOnly;
            File.SetAttributes(SelectedFile, attr);

            SelectedGameData.ArcadeLeaderboards[2].MScores[9].Name = "DKO";
            SelectedGameData.ArcadeLeaderboards[2].MScores[9].Points = 69;

            GameStatsVertical = FilteredGameStats.CollectionViewToVerticalStats(GameStatsVertical);
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
        }

        private async void DelayedButtonEnable(Button button)
        {
            button.IsEnabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(700);
            });
            button.IsEnabled = true;
        }

        private void LoadButton_Clicked(object sender, RoutedEventArgs e)
        {
            OldWindowState = new OldWindowState() {
                SelectedGameData = SelectedGameData,
                GameStatsVertical = GameStatsVertical,
                SelectedFile = SelectedFile,
                FilteredGameStats = FilteredGameStats,
            };

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
        SelectFile:
            if (openFileDialog.ShowDialog() == true)
            {
                if (System.IO.Path.GetFileName(openFileDialog.FileName).Equals("profile.dat"))
                {
                    MessageBoxResult result = MessageBox.Show("Can't edit \"profile.dat\"\n" +
                        "It contains profile data and is not a save file.", @"Can't Open File ¯\_(ツ)_/¯",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                        goto SelectFile;
                    else return;
                }
                SelectedFile = openFileDialog.FileName;
            }
            else return;

            LoadFile();
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFile();
            DelayedButtonEnable(e.Source as Button);
        }

        private void ZeroHundredButton_Click(object sender, RoutedEventArgs e)
        {
            Button buttonSource = e.Source as Button;
            string json;
            if (buttonSource.Name == "HundredButton")
                json = Properties.Resources._100_;
            else if (buttonSource.Name == "ZeroButton")
                json = Properties.Resources._0_;
            else
                throw new ArgumentException();

            SelectedGameData = new GameData();
            SelectedGameData = GameData.FromJson(json);

            GameStatsVertical = new List<GameStat>();
            for (int i = 0; i < SelectedGameData.Gamestats.Names.Length; i++)
            {
                GameStatsVertical.Add(new GameStat(i + 1, SelectedGameData.Gamestats.Names[i], SelectedGameData.Gamestats.Values[i]));
            }

            FilteredGameStats = new GameStatsListCollectionViews(GameStatsVertical);

            DataContext = null;
            DataContext = this;

            DelayedButtonEnable(buttonSource as Button);
        }

        private void LoadFile()
        {
            try
            {
                SelectedGameData = new GameData();
                SelectedGameData = GameData.FromJson(File.ReadAllText(SelectedFile));

                GameStatsVertical = new List<GameStat>();
                for (int i = 0; i < SelectedGameData.Gamestats.Names.Length; i++)
                {
                    GameStatsVertical.Add(new GameStat(i + 1, SelectedGameData.Gamestats.Names[i], SelectedGameData.Gamestats.Values[i]));
                }

                FilteredGameStats = new GameStatsListCollectionViews(GameStatsVertical);

                var attr = File.GetAttributes(SelectedFile);
                if (attr == (attr | FileAttributes.ReadOnly))
                {
                    ReadOnlyCheckBox.IsChecked = true;
                }
                else if (attr == (attr & ~FileAttributes.ReadOnly))
                {
                    ReadOnlyCheckBox.IsChecked = false;
                }

                ReloadButton.IsEnabled = true;
                SaveButton.IsEnabled = true;
                ReadOnlyCheckBox.IsEnabled = true;
                ZeroButton.IsEnabled = true;
                HundredButton.IsEnabled = true;
                DataEditView.IsEnabled = true;

                DataContext = null;
                DataContext = this;
                
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show($"There was an error loading \"{SelectedFileDisplay}\".\n" +
                    "Check to see if your save file is valid and up to date.\n\n" +
                    "Do you want to save the file as a blank file?\nThe save data will be lost.\n\n" +
                    "Error Message: " + e.Message +
                    "\nSource: " + e.StackTrace.Substring(0,Math.Min(200, e.StackTrace.Length)),
                    @"Can't Open File ¯\_(ツ)_/¯",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    string json = Properties.Resources._0_;

                    SelectedGameData = new GameData();
                    SelectedGameData = GameData.FromJson(json);

                    GameStatsVertical = new List<GameStat>();
                    for (int i = 0; i < SelectedGameData.Gamestats.Names.Length; i++)
                    {
                        GameStatsVertical.Add(new GameStat(i + 1, SelectedGameData.Gamestats.Names[i], SelectedGameData.Gamestats.Values[i]));
                    }

                    FilteredGameStats = new GameStatsListCollectionViews(GameStatsVertical);

                    var attr = File.GetAttributes(SelectedFile);
                    if (attr == (attr | FileAttributes.ReadOnly))
                    {
                        ReadOnlyCheckBox.IsChecked = true;
                    }
                    else if (attr == (attr & ~FileAttributes.ReadOnly))
                    {
                        ReadOnlyCheckBox.IsChecked = false;
                    }

                    ReloadButton.IsEnabled = true;
                    SaveButton.IsEnabled = true;
                    ReadOnlyCheckBox.IsEnabled = true;
                    ZeroButton.IsEnabled = true;
                    HundredButton.IsEnabled = true;
                    DataEditView.IsEnabled = true;

                    DataContext = null;
                    DataContext = this;

                    SaveFile();
                }
                else
                {
                    SelectedGameData = OldWindowState.SelectedGameData;
                    GameStatsVertical = OldWindowState.GameStatsVertical;
                    SelectedFile = OldWindowState.SelectedFile;
                    FilteredGameStats = OldWindowState.FilteredGameStats;
                }
                
                if (result == MessageBoxResult.No)
                {
                    LoadButton_Clicked(null, null);
                }
            }
        }
    }
}
