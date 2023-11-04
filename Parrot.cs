namespace GameConsole
{
    public class Parrot : Bird
    {
        public Parrot(string name, int price, int age, string bitmapPath) : base(name, price, age, bitmapPath) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name}, the parrot, talks!");
        }

        public override void Feed(Player player)
        {
            if (HungerLevel == 0)
            {
                Console.WriteLine($"{Name} is not hungry right now.");
                return;
            }
            if (player.Money >= FeedCost)
            {
                Console.WriteLine($"It costs {FeedCost} coins to buy food for {Name}");
                Console.WriteLine($"{Name} eats seeds and nuts.");
                HungerLevel -= 50;
                if (HungerLevel == 0) Console.WriteLine($"{Name} is now full.");
                else Console.WriteLine($"{Name} is now less hungry.");
                player.Money -= FeedCost;
            }
            else
            {
                Console.WriteLine($"Not enough money to buy food for {Name}");
            }
         }

        public override void Interact()
        {
            if (HungerLevel >= 80)
            {
                Console.WriteLine($"{Name} is too hungry to interact right now.");
                return;
            }
            Speak();
            Console.WriteLine($"{Name} entertains the visitors by mimicking their words.");
        }
    }
}
