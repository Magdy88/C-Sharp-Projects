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

        // ADD Product 
        // Update Product 
        // View Product  (ID , Name , Quinty ,Price)
        // Exit

        static string[,] Inventory = new string[50, 3];
        static int productarr = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter YOur Inventory System , Choise YOur Questions");
            Console.WriteLine("==================================================");

            Console.WriteLine("1. Add Prodact");
            Console.WriteLine("2. Update Prodact");
            Console.WriteLine("3. View Prodact");
            Console.WriteLine("4. Exit");

           string answerQ= Console.ReadLine();
            int Choise = Convert.ToInt32(answerQ);


           
            switch (Choise)
            {

                case 1:
                        AddProduct();
                    break;
                case 2:
                        UpdateProduct();
                    break;
                case 3:
                        ViewProduct();
                    break;
                case 4:
                    
                    Environment.Exit(0);
                    break;


            }

            }



            Console.ReadKey();
        }

        static public void  AddProduct()
        {
            Console.WriteLine("ADD Your Product\n");

            Console.WriteLine("Enter Your Product Name :");
            string name= Console.ReadLine();

            Console.WriteLine("Enter Your Quentity :");
            string Quentity = Console.ReadLine();

            Console.WriteLine("Enter Your Price :");
            string Price = Console.ReadLine();

            Inventory[productarr, 0] = name;
            Inventory[productarr, 1] = Quentity;
            Inventory[productarr, 2] = Price;

            productarr++;


            Console.WriteLine("Product Added Successfuly\n ");

        }

        static public void ViewProduct()
        {
            if(productarr>0)
            {
                Console.WriteLine("Product List :");
                for(int i=0;i< productarr;i++)
                {
                    Console.WriteLine($" Product ID = {i},Product ID = {Inventory[i,0]}" +
                        $"Product ID = {Inventory[i,1]},Product ID = {Inventory[i,2]}");
                }
            }
            

        }

        static public void UpdateProduct()
        {

            Console.WriteLine("Enter YOur Product Name To Update");
            string NewName = Console.ReadLine();

            int productID = -1;

            if (productarr>0)
            {
               
                for(int i=0;i< productarr;i++)
                {
                    if (Inventory[i,0] == NewName)
                    {
                       productID= i;
                        break;
                    }
                }

                if(productID!=-1)
                {
                    Console.WriteLine("Enter New Quentity");
                    string newQuentity = Console.ReadLine();

                    Inventory[productID,1]= newQuentity;
                }
                else
                {
                    Console.WriteLine("Product Not Found");
                }
            }
            else
            {
                Console.WriteLine("There is Not Product Added");
            }
        }

    }
}
