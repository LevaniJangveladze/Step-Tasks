namespace ConsoleApp16.Models
{
    internal sealed class Warrior : Character
    {
        public override void SuperPower()
        {
           Console.ForegroundColor = ConsoleColor.DarkRed;
           Console.WriteLine($"{Name} becomes berserker and eats alive");
           Console.ResetColor();
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a sword for {Damage} damage!");
        }
    }
}
