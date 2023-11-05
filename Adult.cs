namespace GameConsole
{
    public class Adult : Visitor
    {
        public Adult(string name, int money) : base(name, money) { }

        public override void Interact(Player player, Visitor visitor, Animal animal)
        {
            if (animal.HungerLevel < 80)
            {
                animal.HungerLevel += 10;
                if (visitor.Money >= 7)
                {
                    Console.WriteLine($"{Name} appreciates the zoo's conservation efforts and makes a donation.");
                    player.Money += 7; // Increase player's money for interaction
                    Console.WriteLine("+7 coins.\n");
                    visitor.Money -= 7;
                    animal.HappinessLevel += 1;
                }
                else
                {
                    Console.WriteLine($"{Name} appreciates the zoo's conservation efforts but not enough money to make a donation.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} is disappointed as {animal.Name} is too hungry to interact.");
            }
        }
    }
}