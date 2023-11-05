namespace GameConsole
{
    public enum AnimalType
    {
        Mammal,
        Bird,
        Reptile
    }

    public class AnimalFactory
    {
        public static Animal CreateAnimal(AnimalType type, string name, int price, int age, string bitmapPath)
        {
            switch (type)
            {
                case AnimalType.Mammal:
                    return new Mammal(name, price, age, bitmapPath);
                case AnimalType.Bird:
                    return new Bird(name, price, age, bitmapPath);
                case AnimalType.Reptile:
                    return new Reptile(name, price, age, bitmapPath);
                // Add other cases for different animals
                default:
                    throw new ArgumentException("Invalid animal type");
            }
        }
    }
}
