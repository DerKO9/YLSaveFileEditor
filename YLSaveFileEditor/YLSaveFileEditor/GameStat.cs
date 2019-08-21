namespace YLSaveFileEditor
{
    public partial class MainWindow
    {
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
