namespace GameConsole
{
    public class Player
    {
        private int _money;

        public Player(int money)
        {
            _money = money;
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
    }
}
