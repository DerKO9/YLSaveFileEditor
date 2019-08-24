using System.Collections.Generic;
using System.Linq;

namespace YLSaveFileEditor
{
    internal class OldWindowState
    {
        public GameData SelectedGameData { get; set; } = new GameData();
        public List<GameStat> GameStatsVertical { get; set; } = new List<GameStat>();
        public GameStatsListCollectionViews FilteredGameStats { get; set; }
        public string SelectedFile { get; set; } = "";
        public string SelectedFileDisplay { get => SelectedFile.Split('\\').LastOrDefault(); }
        public bool FileReadOnly { get; set; } = false;
    }
}