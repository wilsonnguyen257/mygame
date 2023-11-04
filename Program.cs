using SplashKitSDK;

namespace GameConsole
{
    public class Program
    {
        private static bool _running = true;
        private static Zoo zoo;
        private static Player player;

        public static void Main()
        {
            player = new Player(50);
            zoo = new Zoo();

            // Initialize Visitors
            Visitor Alice = new Child("Alice", 20);
            Visitor Bob = new Child("Bob", 20);
            Visitor Wilson = new Adult("Wilson", 10);
            Visitor Helen = new Adult("Helen", 10);
            Visitor Guest = new Visitor("Guest", 10);

            zoo.AddVisitors(Helen);
            zoo.AddVisitors(Wilson);
            zoo.AddVisitors(Alice);
            zoo.AddVisitors(Bob);

            // Start the console thread
            Thread consoleThread = new Thread(new ThreadStart(ConsoleLoop));
            consoleThread.Start();

            // Create the window for graphical display
            Window w = new Window("Zoo Tycoon", 500, 500);

            // Main game loop for graphical processing
            while (_running && !w.CloseRequested)
            {
                SplashKit.ProcessEvents();

                // Your drawing code here, e.g., render zoo layout, animals, etc.
                w.Clear(Color.White);
                // Add drawing routines here

                int coinDisplayX = 20; // X position; 20 pixels from the right edge of the window
                int coinDisplayY = w.Height - 20; // Y position; 20 pixels from the top of the window

                // Draw the coins text
                w.DrawText("Coins: " + player.Money, Color.Red, coinDisplayX, coinDisplayY);

                zoo.DrawAnimals(w);

                w.Refresh();
                SplashKit.Delay(60);
            }

            consoleThread.Join(); // Wait for the console thread to finish if it's still running
            w.Close(); // Close the graphical window
        }

        private static void ConsoleLoop()
        {
            Console.WriteLine("\nWelcome to the Zoo Management Game!");
            bool exitConsole = false;

            while (!exitConsole && _running)
            {
                Console.WriteLine("\n1. Open Zoo for the Day");
                Console.WriteLine("2. Buy an Animal from Supplier");
                Console.WriteLine("3. Sell an Animal");
                Console.WriteLine("4. Check Balance and Inventory");
                Console.WriteLine("5. Feed an Animal");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        zoo.OpenForDay(player);
                        break;
                    case 2:
                        zoo.BuyAnimalFromSupplier(player);
                        break;
                    case 3:
                        zoo.SellAnimal(player);
                        break;
                    case 4:
                        zoo.CheckBalanceAndInventory(player);
                        break;
                    case 5:
                        zoo.FeedAnimal(player);
                        break;
                    case 6:
                        exitConsole = true;
                        _running = false;
                        Console.WriteLine("Exiting the game. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}
