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



           //Choice variable to track the input
            int choice;


            //Bool varibale to flag if it is success or not
            bool isSuccess = false;

            //Initialized message
            string message = "";


            do
            {

                //Print the list

                Console.WriteLine("\n********Welcome admin*****");

                Console.WriteLine("1. Insert Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Display All Customers");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice:");



                //Convert to int 16

                choice = Convert.ToInt32(Console.ReadLine());



                switch(choice)
                {


                    case 1:
                        //Declare an instance of customer
                        var customer = new Customer();

                        //Get the customer code input
                        Console.Write("Enter Customer Code: ");
                        customer.CustomerCode = Console.ReadLine() ?? string.Empty;

                        //Get the customer name
                        Console.Write("Enter Customer Name: ");
                        customer.CustomerName = Console.ReadLine() ?? string.Empty;

                        //Call the insert function
                        customer.Insert();

                        
                        break;



                    case 2:


                        //Declare an instance of the customer
                        customer = new Customer();


                        //Get the customer id input
                        Console.Write("Enter Customer ID: ");
                        string input = Console.ReadLine() ?? string.Empty;

                        //Declare the update id
                        int updateId;

                        //Parse the input
                        if (int.TryParse(input, out updateId))
                        {

                            //Get the customer code
                            Console.Write("Enter Customer Code: ");
                            string? customerCode = Console.ReadLine();

                            //Get the customer name
                            Console.Write("Enter Customer Name: ");
                            string? customerName = Console.ReadLine();

                            // Call the Update method
                            customer.Update(updateId, customerCode ?? string.Empty, customerName ?? string.Empty);
                        }
                        else
                        {

                            //Flag the isSucess to false meaning error message
                            isSuccess = false;


                            //the customize error message
                            message = "Invalid Input please enter a int value!";

                            //Pass the bool and string value to the static function in customer.cs
                            Customer.SuccessConsoleColor(message, isSuccess);
                            
                        }



                        
                        break;

                    case 3:


                        //Declare an instance of the customer
                        customer = new Customer();


                        //Get the customer ID
                        Console.Write("Enter Customer ID: ");

                        //Declare input string variable
                        string inputs = Console.ReadLine() ?? string.Empty;


                        //Declare deletedId 
                        int deleteId;

                        //Parse the inputs 
                        if (int.TryParse(inputs, out deleteId))
                        {
                     
                            //Call the function and pass the valid id
                            customer.Delete(deleteId);
                             
                        }
                        else
                        {
                            //Flag the isSucess to false meaning error message
                            isSuccess = false;

                            //the customize error message
                            message = "Invalid Input please enter a int value!";


                            //Pass the bool and string value to the static function in customer.cs

                            Customer.SuccessConsoleColor(message, isSuccess);

                        }


                        break;


                    case 4:
                        //Display all the list of customer
                        Customer.DisplayAll();
                       
                        break;

                    case 5:

                        //Declare the foregroundcolor to red
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Exiting Console...");
                        break;

                    default:

                        //Notify that the choice is out of the list
                        Console.WriteLine("Invalid input, please choose a number in the list:(");
                        break;

                }
            } while (choice != 5);

        }

      
            
    }
}