using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConsoleAP
{
    internal class Program
    {

      
        private static bool IsCorrectAnswer(string MyAnswer,string copAnswer)
        {
            if(MyAnswer==copAnswer)
            {

                return true;
            }
            else
                return false;
        }
    
      

        static void Main(string[] args)
        {
            string[] Questions = new string[]
            {
                "1. What Is The Captial OF Italy ? ",
                "2. What Is The Red The Great Person OF All Time ? ",
                "3. What Is The Largest Anamal ?"
            };

            string[] Answer = new string[]
            {
                "Rome",
                "Mohamed",
                "Whale"
            };

            Console.WriteLine("Welcome To The Game");
            Console.WriteLine("-----------------------\n");

            Console.WriteLine("Please Answer To The Question");

            int CountTrueAnswer = 0;

            for(int i=0;i<3;i++)
            {
                Console.WriteLine(Questions[i]);
                string WriteAnswer=Console.ReadLine();

                bool correctAnswer = IsCorrectAnswer(WriteAnswer, Answer[i]);

                if(correctAnswer==true)
                {
                    Console.WriteLine("Correct Anwer");
                    CountTrueAnswer++;

                }
                else
                {
                    Console.WriteLine($"Wrong Answer The Answer Is {Answer[i]}");
                }

                
            }

            Console.WriteLine($"You Right Answer Is {CountTrueAnswer} OF 3");
            
            if(CountTrueAnswer>=2)
            {
                Console.WriteLine("Good Recourd ");
            }
            else
            {
                Console.WriteLine("You Need To Work OF YOur Self");
            }

            Console.WriteLine("----------Game Over-------------");



            Console.ReadKey();
        }
    }
}
