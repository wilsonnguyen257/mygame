namespace GameConsole
{
    public class Snake : Reptile
    {
        public Snake(string name, int price, int age) : base(name, price, age) 
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name}, the snake, hisses softly!");
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
                Console.WriteLine($"It costs {FeedCost} coins to buy food for {Name}.");
                Console.WriteLine($"{Name} swallows its food whole.");
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
            Console.WriteLine($"{Name} fascinates the visitors with its slithering movements.");
        }
    }
}

