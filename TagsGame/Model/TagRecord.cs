namespace MiniGames
{
    internal class TagRecord
    {
        public TagRecord()
        {
        }

        public TagRecord(string s)
        {
            var field = s.Split('\t');
            Pos = int.Parse(field[0]);
            Date = field[1];
            Time = field[2];
        }
        public override string ToString()
        {
            return $"{Pos}\t{Date}\t{Time}\t";
        }

        public string Date { get; set; }                //дата
        public string Time { get; set; }                //время
        public int Pos { get; set; }                    //позиция
    }
}

