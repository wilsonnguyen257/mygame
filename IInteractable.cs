namespace GameConsole
{
    public interface IInteractable
    {
        public void Interact(Player player, Visitor visitor, Animal animal);
    }
}
