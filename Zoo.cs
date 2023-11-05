using SplashKitSDK;

namespace GameConsole
{
    public class Zoo
    {
        private List<Animal> _animals;
        private List<Visitor> _visitors;
        private List<Animal> _drawableAnimals;

        public Zoo()
        {
            _animals = new List<Animal>(); // Initialize the animals list
            _visitors = new List<Visitor>(); // Initialize the visitors list
            _drawableAnimals = new List<Animal>(); // Initialize the drawableAnimals list
        }

        public void OpenForDay(Player player)
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("The zoo has no animals and cannot open for the day!");
                return;
            }

            Console.WriteLine("The zoo is now open for the day!");

            // Simulate visitors coming to the zoo
            foreach (Visitor visitor in _visitors)
            {
                InteractWithAnimals(player, visitor);
            }
        }

        public void DrawAnimals(Window window)
        {
            // Define the size of the animal avatars and the padding between them
            int avatarWidth = 100; // Width of each animal avatar
            int avatarHeight = 100; // Height of each animal avatar
            int padding = 10; // Padding between avatars

            // Determine the number of animals that can fit in a row
            int animalsPerRow = window.Width / (avatarWidth + padding);

            // Starting positions
            int startX = padding; // Start drawing from the left margin
            int startY = padding; // Start drawing from a margin at the top

            for (int i = 0; i < _drawableAnimals.Count; i++)
            {
                Animal animal = _drawableAnimals[i];

                // Calculate X and Y positions
                int row = i / animalsPerRow;
                int col = i % animalsPerRow;
                int x = startX + col * (avatarWidth + padding + 15);
                int y = startY + row * (avatarHeight + padding + 40); // Additional 40 pixels for text height above the avatar

                // Draw the animal's avatar (Placeholder for your actual drawing logic)
                window.DrawRectangle(Color.Gray, x, y, avatarWidth, avatarHeight);

                // Draw the name of the animal above the avatar
                window.DrawText(animal.Name, Color.Black, x, y + avatarHeight + 5); // Adjust text position if necessary

                // Use the new separate method to draw the animal's avatar
                animal.DrawAvatar(window, x, y);

                // Draw the hunger level below the avatar
                window.DrawText($"Hunger: {animal.HungerLevel}", Color.Black, x, y + avatarHeight + 15); // Adjust text position if necessary
                window.DrawText($"Happiness: {animal.HappinessLevel}", Color.Black, x, y + avatarHeight + 25);
                window.DrawText($"Age: {animal.Age}", Color.Black, x, y + avatarHeight + 35);
                window.DrawText($"Value: {animal.Price}", Color.Black, x, y + avatarHeight + 45);
            }
        }

        private void InteractWithAnimals(Player player, Visitor visitor)
        {
            Random random = new Random();
            int index = random.Next(_animals.Count);
            Animal animal = _animals[index];

            // Interact with the animal
            animal.Interact();

            // Visitor interaction
            visitor.Interact(player, visitor, animal);
        }

        public List<Animal> GetAnimalsForSale()
        {
            // This method returns only the animals that are available for sale
            List<Animal> availableAnimals = new List<Animal>();
            Random randomAge = new Random();
            Random randomPrice = new Random();
            availableAnimals.Add(new Lion("Leo - Lion", randomPrice.Next(100), randomAge.Next(50), "lion.png"));
            availableAnimals.Add(new Parrot("Polly - Parrot", randomPrice.Next(35), randomAge.Next(30), "parrot.png"));
            availableAnimals.Add(new Snake("Sly - Snake", randomPrice.Next(10), randomAge.Next(10), "snake.png"));
            availableAnimals.Add(AnimalFactory.CreateAnimal(AnimalType.Mammal,"Kitty - Cat", randomPrice.Next(20), randomAge.Next(20), "cat.png"));
            availableAnimals.Add(AnimalFactory.CreateAnimal(AnimalType.Bird, "Kar - Owl", randomPrice.Next(40), randomAge.Next(40), "owl.png"));
            availableAnimals.Add(AnimalFactory.CreateAnimal(AnimalType.Reptile, "Brok - Dinosaur", randomPrice.Next(200), randomAge.Next(120), "dinosour.png"));
            availableAnimals.Add(AnimalFactory.CreateAnimal(AnimalType.Mammal, "Xash - Kangaroo", randomPrice.Next(70), randomAge.Next(70), "kangaroo.png"));
            return availableAnimals;
        }

        public void AddVisitors(Visitor visitor)
        {
            _visitors.Add(visitor);
        }

        public void BuyAnimalFromSupplier(Player player)
        {
            DisplayAnimalsForSale();

            int selected = GetAnimalSelectionFromUser();
            AttemptToPurchaseAnimal(selected, player);
        }

        private void DisplayAnimalsForSale()
        {
            List<Animal> animalsForSale = GetAnimalsForSale();
            Console.WriteLine("Animals available for purchase from supplier:");
            for (int i = 0; i < animalsForSale.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {animalsForSale[i].Name} - {animalsForSale[i].Price} coins, Age: {animalsForSale[i].Age}.");
            }
        }

        private void AttemptToPurchaseAnimal(int animalIndex, Player player)
        {
            List<Animal> animalsForSale = GetAnimalsForSale();
            if (animalIndex >= 0 && animalIndex < animalsForSale.Count)
            {
                Animal animalToBuy = animalsForSale[animalIndex];
                if (player.Money >= animalToBuy.Price)
                {
                    _animals.Add(animalToBuy);
                    _drawableAnimals.Add(animalToBuy);
                    player.Money -= animalToBuy.Price;
                    Console.WriteLine($"You bought a {animalToBuy.Name} for {animalToBuy.Price} coins.");
                    OfferToRenameAnimal(animalToBuy);
                }
                else
                {
                    Console.WriteLine("Not enough money to buy this animal.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        private void OfferToRenameAnimal(Animal animal)
        {
            Console.Write("Do you want a new name for this animal? (yes/no): ");
            string choice = Console.ReadLine().Trim().ToLower();
            while (choice != "yes" && choice != "no")
            {
                Console.Write("Enter your choice again: ");
                choice = Console.ReadLine().Trim().ToLower();
                
            }
            if (choice == "yes")
            {
                Console.Write("Enter a new name for this animal: ");
                animal.Name = Console.ReadLine();
                Console.WriteLine($"The animal has been renamed to {animal.Name}.");
            }
}

        private int GetAnimalSelectionFromUser()
        {
            Console.Write("Select the animal you want to buy: ");
            int selected;
            while (!int.TryParse(Console.ReadLine(), out selected) || selected < 1 || selected > GetAnimalsForSale().Count)
            {
                Console.Write($"Invalid input, please enter a number between 1 and {GetAnimalsForSale().Count}: ");
            }
            return selected - 1; // Adjust for 0-based indexing
        }

        public void SellAnimal(Player player)
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("There are no animals in the zoo to sell.");
                return;
            }
            Console.WriteLine("Animals available to sell:");
            int i = 0;
            foreach (Animal animal in _animals)
            {
                i += 1;
                Console.WriteLine($"{i}.{animal.Name} - {animal.Price} coins");
            }
            Console.Write("Select the animal you want to sell: ");
            int selected;
            while (!int.TryParse(Console.ReadLine(), out selected))
            {
                Console.WriteLine("Invalid input, please enter a number: ");
            }
            selected -= 1;
            if (selected >= 0 && selected < _animals.Count)
            {
                Animal animalToSell = _animals[selected];
                _animals.RemoveAt(selected);
                _drawableAnimals.Remove(animalToSell);
                player.Money += animalToSell.Price;
                Console.WriteLine($"You sold a {animalToSell.Name} for {animalToSell.Price} coins.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void CheckBalanceAndInventory(Player player)
        {
            Console.WriteLine($"Your balance: {player.Money} coins");

            if (_animals.Count == 0)
            {
                Console.WriteLine("There are currently no animals in the zoo.");
            }
            else
            {
                Console.WriteLine("Animals in the zoo:");
                for (int i = 0; i < _animals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_animals[i].Name}");
                }
            }
        }

        public void FeedAnimal(Player player)
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("There are no animals in the zoo to feed.");
                return;
            }

            Console.WriteLine("Animals available to feed:");
            int i = 0;
            foreach (Animal animal in _animals)
            {
                i += 1;
                Console.WriteLine($"{i}.{animal.Name}");
            }
            Console.Write("Select the animal you want to feed: ");
            int selected;
            while (!int.TryParse(Console.ReadLine(), out selected))
            {
                Console.WriteLine("Invalid input, please enter a number: ");
            }
            selected -= 1;
            if (selected >= 0 && selected < _animals.Count)
            {
                Animal animalToFeed = _animals[selected];
                animalToFeed.Feed(player);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                _animals.Add(animal);
                Console.WriteLine($"{animal.Name} has been added to the zoo!");
            }
            else
            {
                Console.WriteLine("Invalid animal. Cannot add to the zoo.");
            }
        }
    }
}
