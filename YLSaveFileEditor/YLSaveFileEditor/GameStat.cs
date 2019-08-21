using System.ComponentModel;

namespace YLSaveFileEditor
{
    public class GameStat : INotifyPropertyChanged
    {
        private int _value;

        public GameStat(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
        public int Id { get; }
        public string Name { get; }
        public int Value {
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
