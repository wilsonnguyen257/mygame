namespace GameConsole
{
    public abstract class LivingBeing
    {
        private string _name;
        public LivingBeing(string name)
        {
            _name = name;
        }
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public abstract void Speak();
    }
}
