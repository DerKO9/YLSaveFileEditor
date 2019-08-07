using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YLSaveFileEditor
{

    public partial class GameData
    {
        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("worlds")]
        public World[] Worlds { get; set; }

        [JsonProperty("arcadeLeaderboards")]
        public ArcadeLeaderboard[] ArcadeLeaderboards { get; set; }

        [JsonProperty("gamestats")]
        public Gamestats Gamestats { get; set; }

        [JsonProperty("tonics")]
        public Tonics Tonics { get; set; }
    }

    public class ArcadeLeaderboard
    {
        [JsonProperty("leaderboardName")]
        public string LeaderboardName { get; set; }

        [JsonProperty("leaderboardSortType")]
        public long LeaderboardSortType { get; set; }

        [JsonProperty("leaderboardScoreType")]
        public long LeaderboardScoreType { get; set; }

        [JsonProperty("scoreFormat")]
        public string ScoreFormat { get; set; }

        [JsonProperty("mLeaderboardSize")]
        public long MLeaderboardSize { get; set; }

        [JsonProperty("mPlayerHasCompleted")]
        public bool MPlayerHasCompleted { get; set; }

        [JsonProperty("mPlayerHasSetHighScore")]
        public bool MPlayerHasSetHighScore { get; set; }

        [JsonProperty("mPagiePendingGameStat")]
        public long MPagiePendingGameStat { get; set; }

        [JsonProperty("mScores")]
        public MScore[] MScores { get; set; }
    }

    public class MScore
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }
    }

    public class Gamestats
    {
        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("values")]
        public int[] Values { get; set; }
    }

    public class Player
    {
        [JsonProperty("playtime")]
        public int Playtime { get; set; }

        [JsonProperty("arcadeTokenCount")]
        public int ArcadeTokenCount { get; set; }

        [JsonProperty("healthExtenderTokenCount")]
        public int HealthExtenderTokenCount { get; set; }

        [JsonProperty("specialExtenderTokenCount")]
        public int SpecialExtenderTokenCount { get; set; }

        [JsonProperty("moveEnabled")]
        public int[] MoveEnabled { get; set; }

        [JsonProperty("paidTrowza")]
        public int PaidTrowza { get; set; }

        [JsonProperty("unspentPagies")]
        public int UnspentPagies { get; set; }

        [JsonProperty("spentCasinoChips")]
        public int SpentCasinoChips { get; set; }
    }

    public class Tonics
    {
        private int[] active = new int[16];

        [JsonProperty("active")]
        public int[] Active
        {
            get
            {
                for (int i = 0; i < active.Length; i++)
                {
                    if (active[i] == 1)
                    active[i] = i + 1;
                }
                return active;
            }
            set
            {
                if (value.Length != 16) Array.Resize(ref value, 16);
                active = value;
            }
        }
    }

    public class World
    {
        [JsonProperty("coinCount")]
        public int CoinCount { get; set; }

        [JsonProperty("pagieCount")]
        public int PagieCount { get; set; }

        [JsonProperty("coins")]
        public int[] Coins { get; set; }

        [JsonProperty("pagies")]
        public int[] Pagies { get; set; }

        [JsonProperty("ghostwriters")]
        public int[] Ghostwriters { get; set; }

        [JsonProperty("casinochips")]
        public int[] Casinochips { get; set; }

        [JsonProperty("arcadetoken")]
        public int Arcadetoken { get; set; }

        [JsonProperty("healthextendertoken")]
        public int Healthextendertoken { get; set; }

        [JsonProperty("specialextendertoken")]
        public int Specialextendertoken { get; set; }

        [JsonProperty("transformtoken")]
        public int Transformtoken { get; set; }

        [JsonProperty("casinoChipCount")]
        public int CasinoChipCount { get; set; }

        [JsonProperty("genericTokenCount")]
        public int[] GenericTokenCount { get; set; }

        [JsonProperty("letterTokenMask")]
        public int[] LetterTokenMask { get; set; }

        [JsonProperty("worldStateData")]
        public string WorldStateData { get; set; }
    }

    public partial class GameData
    {
        public static GameData FromJson(string json) => JsonConvert.DeserializeObject<GameData>(json);
    }

    public static class Serialize
    {

        public static string ToJson(this GameData self) => JsonConvert.SerializeObject(self, Formatting.Indented);
    }
}