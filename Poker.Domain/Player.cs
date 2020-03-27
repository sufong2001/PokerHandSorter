namespace Poker.Domain
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Hand Hand { get; set; }

        public int WinCount { get; set; }
    }
}