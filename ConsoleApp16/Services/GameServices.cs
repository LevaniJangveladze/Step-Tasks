using ConsoleApp16.Models;

namespace ConsoleApp16.Services
{
    internal class GameServices
    {
       private Random _random = new Random();
       
       private Character CreateCharacter(int choice, string name)
       {
           Character character;

           if (choice == 1)
           {
               character = new Wizard();
           }
           else if (choice == 2)
           {
               character = new Warrior();
           }
           else 
           {
               character = new Archer();
           }
           
           character.Name = name;
           character.Health = 100;
           character.Damage = _random.Next(15, 30);
           
           return character;
       }

       public void Start()
       {
           Console.WriteLine("Choose your character:");
           Console.WriteLine("1. Wizard");
           Console.WriteLine("2. Warrior");
           Console.WriteLine("3. Archer");
           Console.Write("Enter choice:");
           
           int choice = int.Parse(Console.ReadLine());
           Character player = CreateCharacter(choice, "You");
           int enemyChoice = _random.Next(1, 4);
           Character enemy = CreateCharacter(enemyChoice, "Enemy");
           
           Console.WriteLine($"\nYou chose {player.GetType().Name}!");
           player.SuperPower();
           Console.WriteLine($"\nYour opponent is a {enemy.GetType().Name}!");
           enemy.SuperPower();
           
           Fight(player, enemy);
       }
       
       public void Fight(Character player, Character enemy)
       {
           while (player.Health > 0 && enemy.Health >0)
           {
               player.Attack();
               enemy.Health -= player.Damage;
               Console.WriteLine($"Enemy health: {enemy.Health}");

               if (enemy.Health <= 0)
               {
                   break;
               }
               
               enemy.Attack();
               player.Health -= enemy.Damage;
               Console.WriteLine($"Your health: {player.Health}");
               Console.WriteLine("");
           }

           if (player.Health > 0)
           {
               Console.WriteLine($"{player.GetType().Name} wins!");
           }
           else
           {
               Console.WriteLine($"{enemy.GetType().Name} wins!");
           }
       }
    }
}
