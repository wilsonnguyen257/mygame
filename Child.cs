namespace GameConsole
{
    public class Child : Visitor
    {
        public Child(string name, int money) : base(name, money) { }

        public override void Interact(Player player, Visitor visitor, Animal animal)
        {
            if (animal.HungerLevel < 80)
            {
                animal.HungerLevel += 5;
                if (visitor.Money >= 3)
                {
                    Console.WriteLine($"{Name} is amazed by the animals and learns a lot! and donated to the zoo.");
                    player.Money += 3; // Increase player's money for interaction
                    visitor.Money -= 3;
                    Console.WriteLine("+3 coins.\n");
                    animal.HappinessLevel += 10;
                }
                else
                {
                    Console.WriteLine($"{Name} is amazed by the animals and learns a lot!");
                }
            }
            else
            {
                Console.WriteLine($"{Name} is disappointed as {animal.Name} is too hungry to interact.");
            }
        }
    }

}
