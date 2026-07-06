namespace ConsoleApp16.Models
{
    abstract class Character
    {
        public string Name { get; set; }
        
        public int Health { get; set; }
        
        public int Damage { get; set; }

        public abstract void SuperPower();
        public abstract void Attack();
    }
}
