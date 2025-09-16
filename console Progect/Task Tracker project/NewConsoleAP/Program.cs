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
        static string[] Tasks = new string[100];
        static int Taskindex = 0;
        private static string ReadChoise()
        {
            Console.WriteLine("Choose Your Choise From 1 to 5");
            string Choose = Console.ReadLine();
            return Choose;
        }
        private static void Head()
        {
            Console.WriteLine("Welcome To My Task Tracker");
            Console.WriteLine("--------------------------\n");

            Console.WriteLine("1: Add");
            Console.WriteLine("2: View");
            Console.WriteLine("3: Mark");
            Console.WriteLine("4: Remove");
            Console.WriteLine("5: Exit");

            while(true)
            {
                Console.WriteLine("Choose Your Choise From 1 to 5");
                string Choose = Console.ReadLine();

                switch (Choose)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewAllTasks();
                        break;
                    case "3":
                        MarkTask();
                        break;
                    case "4":
                        DeleteTask();
                        break; 
                    case "5":
                        Environment.ExitCode = 0;
                        break;
                    default:
                        Console.WriteLine("Choose Number From 1 to 5");
                        break;



                }

            }


        }


        private static void  AddTask()
        {
            Console.WriteLine("Please Add YOur Task");

            string ADD= Console.ReadLine();

            Tasks[Taskindex] = ADD;
            Taskindex++;
      
           
        }

        private static void ViewAllTasks()
        {
            Console.WriteLine("Tasks List :");

            for(int i=0;i<Taskindex;i++ )
            {
                Console.WriteLine($"Task {i+1} = {Tasks[i]}");
            }
        }

        private static void MarkTask()
        {
            Console.WriteLine("Which Task Done");
            string MARK= Console.ReadLine();

            int num=Convert.ToInt32(MARK);

            Tasks[num] = Tasks[num]+" -- Complete --";
        }

        private static void DeleteTask()
        {
            Console.WriteLine("Which Task Are You Delete");
            string MARK = Console.ReadLine();

            int num = Convert.ToInt32(MARK);


            Tasks[num] = string.Empty;


        }
    
      

        static void Main(string[] args)
        {

         Head();


            Console.ReadKey();
        }
    }
}
