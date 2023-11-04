namespace GameConsole
{
    public interface IInteractable
    {
        void Interact(Player player, Visitor visitor, Animal animal);
    }
}
