using System;
using System.Diagnostics;
using System.Text;
using Test;
namespace ControlFlowDemo
{
    class Program
    {
     
        static void Main(string[] args)
        {



         
            int choice;

            bool isSuccess = false;
            string message = "";
            do
            {

                Console.WriteLine("\n********Welcome admin*****");

                Console.WriteLine("1. Insert Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Display All Customers");


                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice:");


                choice = Convert.ToInt32(Console.ReadLine());



                switch(choice)
                {


                    case 1:

                        var customer = new Customer();
                        Console.Write("Enter Customer Code: ");
                        customer.CustomerCode = Console.ReadLine();
                        Console.Write("Enter Customer Name: ");
                        customer.CustomerName = Console.ReadLine();
                        customer.Insert();
                        break;

                        // Console.WriteLine("Enter MachineName");



                    case 2:

                        customer = new Customer();

                        Console.Write("Enter Customer ID: ");
                        string input = Console.ReadLine();

                        int updateId;
                        if (int.TryParse(input, out updateId))
                        {
                            Console.Write("Enter Customer Code: ");
                            string? customerCode = Console.ReadLine();

                            Console.Write("Enter Customer Name: ");
                            string? customerName = Console.ReadLine();

                            // Call the Update method with the correct parameter order
                            customer.Update(updateId, customerCode, customerName);
                        }
                        else
                        {

                            isSuccess = false;

                            message = "Invalid Input please enter a int value!";

                            Customer.SuccessConsoleColor(message, isSuccess);
                            
                        }



                        
                        break;

                    case 3:

                        customer = new Customer();

                        Console.Write("Enter Customer ID: ");
                        string inputs = Console.ReadLine();

                        int deleteId;
                        if (int.TryParse(inputs, out deleteId))
                        {
                     

                            customer.Delete(deleteId);
                             
                        }
                        else
                        {

                            isSuccess = false;

                            message = "Invalid Input please enter a int value!";

                            Customer.SuccessConsoleColor(message, isSuccess);

                        }


                        break;


                    case 4:

                        Customer.DisplayAll();
                       
                        break;

                    case 5:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Exiting Console...");
                        break;

                    default:

                        Console.WriteLine("Invalid input, please choose a number in the list:(");
                        break;

                }
            } while (choice != 5);

        }

      
            
    }
}