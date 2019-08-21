using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace YLSaveFileEditor
{
    public partial class MainWindow
    {
        public class GameStatsListCollectionViews
        {
            private readonly int[] hubGameStatsIndices = new int[] { 17, 18, 27, 33, 47, 54, 62,
                70, 78, 86, 94, 102, 110, 118, 131, 132, 133, 134, 136, 137, 141, 142, 143, 144,
                145, 167, 181, 182, 201, 202, 218, 219, 224, 228, 251, 279, 285, 292 };
            private readonly int[] jungleGameStatsIndices = new int[] { 11, 19, 28, 34, 48, 55,
                63, 71, 79, 87, 95, 103, 111, 119, 203, 208, 213, 242, 252, 257, 258, 260, 267,
                279, 280, 286, 291, 294 };
            private readonly int[] glacierGameStatsIndices = new int[] { 12, 20, 29, 35, 49, 56,
                64, 72, 80, 88, 96, 104, 112, 120, 185, 186, 187, 188, 189, 190, 191, 192, 193,
                194, 195, 200, 204, 209, 214, 229, 230, 231, 243, 253, 259, 261, 268, 281, 287, 295 };
            private readonly int[] swampGameStatsIndices = new int[] { 13, 21, 30, 36, 50, 57, 65, 73,
                81, 89, 97, 105, 113, 121, 135, 205, 210, 215, 244, 247, 254, 262, 269, 282, 288, 296 };
            private readonly int[] casinoGameStatsIndices = new int[] { 14, 22, 31, 38, 52, 59, 67, 75,
                83, 91, 99, 107, 115, 123, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158,
                159, 160, 161, 162, 163, 164, 166, 206, 211, 216, 233, 234, 236, 237, 238, 239, 245, 249,
                255, 263, 270, 277, 283, 289, 297 };
            private readonly int[] spaceGameStatsIndices = new int[] { 15, 23, 32, 37, 51, 58, 66, 74,
                82, 90, 98, 106, 114, 122, 207, 212, 217, 240, 241, 246, 250, 256, 264, 265, 271, 284,
                290, 293, 298 };
            private readonly int[] miscGameStatsIndices = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 16,
                24, 25, 26, 39, 40, 41, 42, 43, 44, 45, 46, 53, 60, 61, 68, 69, 76, 77, 84, 85, 92, 93,
                100, 101, 108, 109, 116, 117, 124, 125, 126, 127, 128, 129, 130, 138, 139, 140, 146, 168,
                169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 183, 184, 196, 197, 198, 199,
                220, 221, 222, 223, 223, 248, 266, 272, 273, 274, 275, 276, 278 }; //Removed 225 CurrentLoadStartPoint so combobox works
            public GameStatsListCollectionViews(List<GameStat> gameStatsVertical)
            {
                HubCollectionView = new ListCollectionView(gameStatsVertical);
                TribalstackCollectionView = new ListCollectionView(gameStatsVertical);
                GlitterglazeCollectionView = new ListCollectionView(gameStatsVertical);
                MoodymazeCollectionView = new ListCollectionView(gameStatsVertical);
                CashinoCollectionView = new ListCollectionView(gameStatsVertical);
                GalaxyCollectionView = new ListCollectionView(gameStatsVertical);
                MiscCollectionView = new ListCollectionView(gameStatsVertical);

                HubCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (hubGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                TribalstackCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (jungleGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                GlitterglazeCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (glacierGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                MoodymazeCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (swampGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                CashinoCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (casinoGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                GalaxyCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (spaceGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };
                MiscCollectionView.Filter = x =>
                {
                    GameStat gameStat = x as GameStat;
                    if (miscGameStatsIndices.Contains(gameStat.Id))
                        return true;
                    return false;
                };

            }
            public ListCollectionView HubCollectionView { get; set; }
            public ListCollectionView TribalstackCollectionView { get; set; }
            public ListCollectionView GlitterglazeCollectionView { get; set; }
            public ListCollectionView MoodymazeCollectionView { get; set; }
            public ListCollectionView CashinoCollectionView { get; set; }
            public ListCollectionView GalaxyCollectionView { get; set; }
            public ListCollectionView MiscCollectionView { get; set; }

            public List<GameStat> CollectionViewToVerticalStats(List<GameStat> gameStatsVertical)
            {
                List<GameStat> hubList = HubCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> jungleList = TribalstackCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> glacierList = GlitterglazeCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> swampList = MoodymazeCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> casinoList = CashinoCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> spaceList = GalaxyCollectionView.SourceCollection.Cast<GameStat>().ToList();
                List<GameStat> miscList = MiscCollectionView.SourceCollection.Cast<GameStat>().ToList();

                for (int i = 0; i < gameStatsVertical.Count; i++)
                {
                    if (hubGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = hubList[i];
                    else if (jungleGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = jungleList[i];
                    else if (glacierGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = glacierList[i];
                    else if (swampGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = swampList[i];
                    else if (casinoGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = casinoList[i];
                    else if (spaceGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = spaceList[i];
                    else if (miscGameStatsIndices.Contains(i + 1))
                        gameStatsVertical[i] = miscList[i];
                }

                return gameStatsVertical;
            }
        }

    }
}
