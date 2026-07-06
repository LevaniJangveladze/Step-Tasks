namespace ConsoleApp16.Models
{
    internal sealed class Wizard : Character
    {
        public override void SuperPower()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} casts a magic fireball!");
            Console.ResetColor();
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a magic staff for {Damage} damage!");
        }
    }
}
