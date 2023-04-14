using System.Security.Cryptography.X509Certificates;

namespace RockPaperScissors
{
    internal class Program
    {
        static string[] hands = new string[3] { "Rock", "Paper", "Scissors" };
        static int playerChoise = 0;
        static string cpuChoise;
        static int playerScore = 0;
        static int cpuScore = 0;
        static bool wannaQuit = false;

        static void Main(string[] args)
        {            
            Random numGen = new Random();

            do
            {
                Console.WriteLine($"You: {playerScore}      VS.     {cpuScore} :Computer\n");
                Console.WriteLine("Choose you hand.\n 1) Rock\n 2) Paper\n 3) Scissors\n");

                playerChoise = NumChec(Console.ReadLine());
                Console.Clear();
                cpuChoise = hands[numGen.Next(0, 3)];

                Console.WriteLine($"Your choise" + "Computers choise\n".PadLeft(20) );
                Print(hands[playerChoise - 1], cpuChoise);

                WhoWon(cpuChoise);
                
                Console.ReadKey();

                Console.Clear();

                PlayAgain();
                
            } while (!wannaQuit);
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }

        static int NumChec(string number)
        {
            int value = 0;
            bool youShallPass = false;
            do
            {
                if (int.TryParse(number, out value) && value <= 3 && value > 0)
                {
                    youShallPass= true;
                    break;
                }
                else
                {
                    Console.WriteLine("Inavalid number. Choose again.");
                    number = Console.ReadLine();
                }                    
            } while (!youShallPass);
            return value;
        }

        static void WhoWon(string cpu)
        {
            // Checks the different outcomes according to user input and cpu choise

            //playerChoise 1 = Rock 
            if (playerChoise == 1)
            {
                if (cpu.Equals("Paper"))
                {
                    Console.WriteLine("\nPaper beats Rock. Computer win!");
                    cpuScore++;
                }
                else if (cpu.Equals("Scissors"))
                {
                    Console.WriteLine("\nRock beats Scissors. You Win!");
                    playerScore++;
                }
                else { Console.WriteLine("\nIt's a Draw"); }
            }
            //playerChoise 2 = Paper
            if (playerChoise == 2)
            {
                if (cpu.Equals("Scissors"))
                {
                    Console.WriteLine("\nScissoers beat Paper. Computer win!");
                    cpuScore++;
                }
                else if (cpu.Equals("Rock"))
                {
                    Console.WriteLine("\nPaper beats Rock. You Win!");
                    playerScore++;
                }
                else { Console.WriteLine("\nIt's a Draw"); }
            }
            //playerChoise 3 = Scissors
            if (playerChoise == 3)
            {
                if (cpu.Equals("Rock"))
                {
                    Console.WriteLine("\nRock beats Scissors. Computer win!");
                    cpuScore++;
                }
                else if (cpu.Equals("Paper"))
                {
                    Console.WriteLine("\nScissoers beat Paper. You Win!");
                    playerScore++;
                }
                else { Console.WriteLine("\nIt's a Draw"); }
            }
        }

        static void PlayAgain()
        {
            if (playerScore == 3)
            {
                Console.WriteLine("Congratulations you won!!\n");
                Console.WriteLine("Press enter to play again or type quit.");
                string quit = Console.ReadLine().ToLower();
                if (quit.Equals("quit"))
                {
                    wannaQuit = true;
                }
                playerScore = 0;
                cpuScore = 0;
            }
            else if (cpuScore == 3)
            {
                Console.WriteLine("Computer won. Better Luck next time!\n");
                Console.WriteLine("Press enter to play again or type quit.");
                string quit = Console.ReadLine().ToLower();
                if (quit.Equals("quit"))
                {
                    wannaQuit = true;
                }
                playerScore = 0;
                cpuScore = 0;
            }
            
            Console.Clear();
        }

        static void Print(string player, string cpu)
        {
            //Aligns the center of the word with representing player.
            int z = player.Length/2;
            int x = 5 + z;
            int y = 14 - z + cpu.Length;

            Console.WriteLine(player.PadLeft(x) + cpu.PadLeft(y));
        }
    }
}