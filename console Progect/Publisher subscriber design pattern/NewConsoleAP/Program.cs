using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NewConsoleAP
{


    public class OrderEventArgs : EventArgs
    { 
        public int OrderID { get; }

        public int OrderTotalPrice { get; }

        public string ClientEmail { get; }


        public OrderEventArgs(int orderID, int OrderTotalPrice,string clientEmail)
        {
           this. OrderID = orderID;
            this.OrderTotalPrice = OrderTotalPrice;
            this.ClientEmail = clientEmail;

        }

    }

    public class Order
    { 

        public event EventHandler<OrderEventArgs> OnOrderCreate;

        public void Create(int orderid ,int ordertotalprice,string clientEmail)
        {
            Console.WriteLine("New order created; now will notify everyone by raising the event.\n");

            //if(OnOrderCreate != null)
            //{
            //    OnOrderCreate(this,new OrderEventArgs(orderid,ordertotalprice,clientEmail));
            //}

            OnOrderCreate.Invoke(this,new OrderEventArgs(orderid, ordertotalprice,clientEmail));
        }

    }


    public class EmailServes
    { 

        public void Subscribe(Order order)
        {
            order.OnOrderCreate += HandelNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreate -= HandelNewOrder;
        }


        public void HandelNewOrder(object sender,OrderEventArgs e)
        {
            Console.WriteLine($"----------------Email Service------------------");
            Console.WriteLine($"Email Service Object Recieved a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nSend an Email");
            Console.WriteLine($"-----------------------------------------------");
            // write the code to send email 
            Console.WriteLine();

        }
    
    
    }

    public class SMSService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreate += HandleNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreate -= HandleNewOrder;
        }


        public void HandleNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"----------------SMS Service------------------");
            Console.WriteLine($"SMS Service Object Recieved a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nSend an SMS");
            Console.WriteLine($"-----------------------------------------------");
            // write the code to send SMS 
            Console.WriteLine();
        }
    }

    public class ShippingService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreate += HandleNewOrder;
        }

        public void UnSubscribe(Order order)
        {
            order.OnOrderCreate -= HandleNewOrder;
        }


        public void HandleNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"----------------Shipping Service------------------");
            Console.WriteLine($"Shipping Service Object Recieved a new order event");
            Console.WriteLine($"Order ID: {e.OrderID}");
            Console.WriteLine($"Order Price: {e.OrderTotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine($"\nSend an Shipping");
            Console.WriteLine($"-----------------------------------------------");
            // write the code to send Shipping 
            Console.WriteLine();
        }
    }






    internal class Program
    {

        static void Main(string[] args)
        {
      
            Order order = new Order();

            EmailServes emailServes = new EmailServes();
            SMSService smsService = new SMSService();
            ShippingService shippingService = new ShippingService();


            emailServes .Subscribe(order );

            smsService .Subscribe(order);
            smsService .UnSubscribe(order);

            shippingService .Subscribe(order);


            order.Create(1, 540, "Mega@gmail.com");
            order.Create(5, 100, "BABA@gmail.com");




            Console.ReadKey();
        }



    }




 





}
