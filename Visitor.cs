namespace GameConsole
{
    public abstract class Visitor : LivingBeing, IInteract
    {
        private int _money;
        public Visitor(string name, int money) : base(name)
        {
            _money = money;
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: 'Hello!'");
        }

        public abstract void Interact(Player player, Visitor visitor, Animal animal);
    }
}
