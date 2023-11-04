using SplashKitSDK;

namespace GameConsole
{
    public abstract class Animal : LivingBeing
    {
        private int _price;
        private int _feedcost;
        private int _hungerLevel;
        private int _happinessLevel;
        private int _age;
        private Bitmap _avatar;


        public Animal(string name, int price, int feedcost, int age, string bitmapPath) : base(name)
        {
            _price = price;
            _feedcost = feedcost;
            _hungerLevel = 50;
            _happinessLevel = 10;
            _age = age;
            // Load the bitmap for the animal's avatar
            _avatar = SplashKit.LoadBitmap(name, bitmapPath);
        }

        public Bitmap Avatar 
        {
            get { return _avatar; }  
        }

        // Add a method to draw the animal's avatar
        public void DrawAvatar(Window window, float x, float y)
        {
            window.DrawBitmap(Avatar, x, y);
        }

        // Make sure to release the bitmap when the animal is no longer needed
        public void ReleaseResources()
        {
            SplashKit.FreeBitmap(Avatar);
        }

        public int HappinessLevel 
        {
            get { return _happinessLevel; }
            set { _happinessLevel = Math.Clamp(value, 0, 10); } 
        }
        public int Age 
        {
            get { return _age; } 
        }

        public int HungerLevel
        {
            get { return _hungerLevel; }
            set { _hungerLevel = Math.Clamp(value, 0, 100); }
        }

        public int FeedCost
        {
            get { return _feedcost; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public abstract void Feed(Player player);
        public abstract void Interact();
    }
}
