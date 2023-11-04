namespace GameConsole
{
    public class Visitor : LivingBeing, IInteractable
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

        public virtual void Interact(Player player, Visitor visitor, Animal animal)
        {
            if (animal.HungerLevel < 80)
            {
                animal.HungerLevel += 3;
                if (visitor.Money >= 1)
                {
                    Console.WriteLine($"{Name} enjoys their visit to the zoo and make a donation.");
                    player.Money += 1; // Increase player's money for interaction
                    Console.WriteLine("+1 coins.\n");
                    visitor.Money -= 1;
                    animal.HappinessLevel += 2;
                }
                else
                {
                    Console.WriteLine($"{Name} enjoys their visit to the zoo but not enough money to make a donation.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} is disappointed as {animal.Name} is too hungry to interact.");
            }
        }
    }
}
