namespace GameConsole
{
    public class Lion : Mammal
    {
        public Lion(string name, int price, int age, string bitmapPath) : base(name, price, age, bitmapPath)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name}, the lion, roars!");
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
                Console.WriteLine($"{Name} eats meat.");
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
            Console.WriteLine($"{Name} impresses the visitors with its majestic mane.");
        }
    }
}
