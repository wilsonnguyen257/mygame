namespace GameConsole
{
    public class Bird : Animal
    {
        public Bird(string name, int price, int age, string bitmapPath) : base(name, price, 4, age, bitmapPath)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name}, a bird, chirps!");
        }

        public override void Feed(Player player)
        {
            if (HungerLevel < 50)
            {
                Console.WriteLine($"{Name} is not hungry right now.");
                return;
            }
            if (player.Money >= FeedCost)
            {
                Console.WriteLine($"It costs {FeedCost} coins to buy some seeds for {Name}.");
                Console.WriteLine($"{Name} pecks at some seeds.");
                HungerLevel -= 50;
                if (HungerLevel == 0) Console.WriteLine($"{Name} is now full.");
                else Console.WriteLine($"{Name} is now less hungry.");
                player.Money -= FeedCost;
                HappinessLevel += 1;
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
                HappinessLevel -= 3;
                return;
            }
            Speak();
            Console.WriteLine($"{Name} flutters around playfully.");
        }
    }
}
