using System;
using System.Threading;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog gela = new Dog() { Name = "Gela" };
            Cat jemala = new Cat() { Name = "Jemala" };

            Intro(gela, jemala);

            while (true)
            {
                Console.Write("\nPress SPACE to fight: ");
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key != ConsoleKey.Spacebar)
                {
                    Console.WriteLine("\ninvalid key.");
                    continue;
                }

                // --- One full round: cat strikes first, then dog strikes back ---

                jemala.Attack(gela);                       // cat -> dog
                if (gela.Health <= 0) { Victory(jemala); return; }
                Thread.Sleep(600);

                gela.Attack(jemala);                       // dog -> cat
                if (jemala.Health <= 0) { Victory(gela); return; }
                Thread.Sleep(600);

                ShowStatus(gela, jemala);
            }
        }

        // ---------- Screens & UI helpers (these stay in Program) ----------

        static void Intro(Animal dog, Animal cat)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ===========================================
   ||        D O G   vs   C A T   ! ! !     ||
   ===========================================
");
            Console.ResetColor();
            Console.WriteLine($"   {dog.Name} (DOG)    HP: {dog.Health}");
            Console.WriteLine($"   {cat.Name} (CAT)    HP: {cat.Health}");
            Console.WriteLine("\n   Press SPACE each round to make them fight.");
            Console.WriteLine("   Block TWICE in a row to charge your ULTIMATE!");
        }

        static void ShowStatus(Animal dog, Animal cat)
        {
            Console.Clear();
            Console.WriteLine("============== STATUS ==============\n");
            DrawBar(dog);
            DrawBar(cat);
            Console.WriteLine();
            if (dog.UltReady) Highlight($"   {dog.Name}'s ULTIMATE is READY!", ConsoleColor.Red);
            if (cat.UltReady) Highlight($"   {cat.Name}'s ULTIMATE is READY!", ConsoleColor.Magenta);
            Console.WriteLine("====================================");
        }

        // Draws a colored health bar like:   Gela     [#########-----------] 96/150
        static void DrawBar(Animal a)
        {
            int total = 20;
            double ratio = a.MaxHealth == 0 ? 0 : (double)a.Health / a.MaxHealth;
            int filled = (int)Math.Round(ratio * total);
            if (filled < 0) filled = 0;
            if (filled > total) filled = total;

            string bar = new string('#', filled) + new string('-', total - filled);

            Console.ForegroundColor = ratio > 0.5 ? ConsoleColor.Green
                                    : ratio > 0.25 ? ConsoleColor.Yellow
                                    : ConsoleColor.Red;
            Console.WriteLine($"   {a.Name,-8} [{bar}] {a.Health}/{a.MaxHealth}");
            Console.ResetColor();
        }

        static void Highlight(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void Victory(Animal winner)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
   *  *  *  *  *  *  *  *  *  *  *  *  *  *
          W  I  N  N  E  R  !  !  !
   *  *  *  *  *  *  *  *  *  *  *  *  *  *
");
            Console.WriteLine($"             >>>   {winner.Name}   <<<");
            Console.ResetColor();
            Console.WriteLine("\n   Thanks for playing!");
        }
    }

 

    internal class Dog : Animal
    {
       
        public override void AttackAnimation(Animal enemy)
        {
            string f1 = @"
    /^-----^\                      /\_/\
    V  o o  V                     ( o.o )
     \  w  /     - - lunge ->      > ^ <
      DOG                          CAT
";
            string f2 = @"
    /^-----^\___                   /\_/\
    V  o o  V   \============>>>> ( o.o )
     \  w  /        CHOMP!!!       > ^ <
      DOG bites the cat!           CAT
";
            string f3 = @"
    /^-----^\                      /\_/\
    V  ^ ^  V                     ( x.x )
     \  w  /                       > ~ <   ouch!
      DOG                          CAT
";
            Animate(f1, ConsoleColor.Gray, 300);
            Animate(f2, ConsoleColor.Red, 520);
            Animate(f3, ConsoleColor.Yellow, 450);
        }

      
        public override void BlockAnimation()
        {
            string f = @"
    /^-----^\   [ B L O C K ! ]    /\_/\
    V  -.-  V   ||==========||    ( >.> )
     \  w  /    ||  SHIELD  ||     > ^ <
      DOG holds the line!          CAT
";
            Animate(f, ConsoleColor.Blue, 750);
        }

  
        public override void UltAnimation(Animal enemy)
        {
            string charge = @"
                \   |   /
              --  BEAST  --
             D O G   M O D E
                /   |   \
           grrrrrrr...  *  *  *
";
            string strike = @"
    /^-------^\=============================>>>>
    V  > <  V    G I A N T   J A W S   >>>>>>>>   ( X_X )
     \ WWWWW /=============================>>>>      CAT
        ** BEAST MODE BITE **
";
            Animate(charge, ConsoleColor.DarkYellow, 650);
            UltBanner(Name, "BEAST  MODE  BITE", ConsoleColor.Red);
            Animate(strike, ConsoleColor.Red, 750);
            Explosion(ConsoleColor.Red);
        }
    }

    internal class Cat : Animal
    {
        
        public override void AttackAnimation(Animal enemy)
        {
            string f1 = @"
    /^-----^\                      /\_/\
    V  o o  V                     ( o.o )
     \  w  /        ...ready       > ^ <
      DOG                          CAT
";
            string f2 = @"
    /^-----^\                      /\_/\
    V  o o  V    <///////////     ( >o< )
     \  w  /        SLASH!!!       > ^ <
      DOG                          CAT claws!
";
            string f3 = @"
    /^-----^\                      /\_/\
    V  x x  V                     ( o.o )
     \  w  /   ouch!               > ^ <
      DOG                          CAT
";
            Animate(f1, ConsoleColor.Gray, 300);
            Animate(f2, ConsoleColor.Cyan, 520);
            Animate(f3, ConsoleColor.Yellow, 450);
        }

        // Cat's defense: climbs the tree to dodge
        public override void BlockAnimation()
        {
            string f = @"
                          /\_/\    |||
       /^-----^\         ( o.o )   |||   CAT climbs
       V  o o  V          > ^ <    |||   the tree!
        \  w  /    ...miss...     /|||\
         DOG                       MISSED!
";
            Animate(f, ConsoleColor.Green, 750);
        }

        // Cat's ULTIMATE: Nine Lives Fury
        public override void UltAnimation(Animal enemy)
        {
            string charge = @"
                 *   *   *
               ~  N I N E  ~
              L I V E S
                 *   *   *   *
            shhhhh...   /\_/\
";
            string strike = @"
       /\_/\     S S S L A S H ! !
      ( >o< )  ////////////////////>>>   V x x V
       > ^ <     C L A W   S T O R M        DOG
        ** NINE LIVES FURY **
";
            Animate(charge, ConsoleColor.Magenta, 650);
            UltBanner(Name, "NINE  LIVES  FURY", ConsoleColor.Magenta);
            Animate(strike, ConsoleColor.Cyan, 750);
            Explosion(ConsoleColor.Magenta);
        }
    }

   

    internal class Animal
    {
      
        private static readonly Random _random = new Random();

        public string Name { get; set; } = "";
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int ConsecutiveBlocks { get; set; }  
        public bool UltReady { get; set; }           

        public Animal()
        {
            MaxHealth = _random.Next(120, 161);
            Health = MaxHealth;
        }

        public void Attack(Animal enemy)
        {
           
            if (UltReady)
            {
                UltReady = false;
                Damage = _random.Next(45, 66);
                UltAnimation(enemy);
                enemy.Health = Math.Max(0, enemy.Health - Damage);
                enemy.ConsecutiveBlocks = 0;
                return;
            }

         
            Damage = _random.Next(12, 26);
            bool blocked = _random.Next(0, 100) < 40;   

            if (blocked)
            {
                enemy.BlockAnimation();                
                enemy.ConsecutiveBlocks++;

                if (enemy.ConsecutiveBlocks >= 2)
                {
                    enemy.UltReady = true;
                    enemy.ConsecutiveBlocks = 0;
                    enemy.UltChargedBanner();
                }
            }
            else
            {
                AttackAnimation(enemy);                 
                enemy.Health = Math.Max(0, enemy.Health - Damage);
                enemy.ConsecutiveBlocks = 0;           
            }
        }

    
        protected void Animate(string frame, ConsoleColor color, int delayMs)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(frame);
            Console.ResetColor();
            Thread.Sleep(delayMs);
        }

        protected void UltBanner(string name, string moveName, ConsoleColor color)
        {
            string banner = @"
   ##############################################
   ##                                          ##
   ##         U  L  T  I  M  A  T  E           ##
   ##                                          ##
   ##############################################
";
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(banner);
            Console.WriteLine($"            >>>  {name}: {moveName}  <<<");
            Console.ResetColor();
            Thread.Sleep(950);
        }

        protected void Explosion(ConsoleColor color)
        {
            string e1 = @"
          *        *      *         *
       *     *  *     *  *      *  *
     *   *  *  B O O O M ! !  *  *   *  *
       *  *      *    *     *  *     *
          *    *       *       *  *
";
            string e2 = @"
   # # # # # # # # # # # # # # # # # # # #
   # # # # # # # # # # # # # # # # # # # #
   # # # #   I M P A C T ! ! !   # # # # #
   # # # # # # # # # # # # # # # # # # # #
   # # # # # # # # # # # # # # # # # # # #
";
            Animate(e1, color, 240);
            Animate(e2, color, 240);
            Animate(e1, color, 320);
        }

        public void UltChargedBanner()
        {
            string f = $@"
   >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        {Name} blocked twice in a row!
             ULTIMATE  IS  READY!
   >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
";
            Animate(f, ConsoleColor.Yellow, 1100);
        }

        
        public virtual void AttackAnimation(Animal enemy) { }
        public virtual void BlockAnimation() { }
        public virtual void UltAnimation(Animal enemy) { }
    }
}