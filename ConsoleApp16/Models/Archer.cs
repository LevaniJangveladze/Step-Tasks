namespace ConsoleApp16.Models
{
    internal sealed class Archer : Character
    {
        public override void SuperPower()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} rains down a storm of arrows");
            Console.ResetColor();
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} fires a precise shot for {Damage} damage!");
        }
    }
}
