using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        private string MachineName = CommonTask.ComputerName;


        private static string connectionString = "Server=REJIE\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";


        //Boolean to flag whether it is error or success
       
        bool isSuccess= false;

        //Declaration of message

        string message = "";
        public void Insert()
        {
            try
            {
                if (!CommonTask.IsEmpty(CustomerCode) && !CommonTask.IsEmpty(CustomerName))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "INSERT INTO Customer (CustomerCode, CustomerName, MachineName) VALUES (@CustomerCode, @CustomerName, @MachineName)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                            cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);
                            cmd.Parameters.AddWithValue("@MachineName", MachineName);
                            cmd.ExecuteNonQuery();
                            isSuccess = true;
                            message = "Customer inserted successfully";

                            SuccessConsoleColor(message, isSuccess);
                            Console.Beep();
                            Customer.DisplayAll();

                        }
                    }
                }
                else
                {
                    isSuccess= false; 
                   message="CustomerCode or CustomerName cannot be empty.";
                   SuccessConsoleColor(message, isSuccess);

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Update(int id, string customerCode, string newCustomerName)
        {
            try
            {
                // Check if both CustomerCode and CustomerName are not empty
                if (!CommonTask.IsEmpty(customerCode) && !CommonTask.IsEmpty(newCustomerName))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "UPDATE Customer SET CustomerCode = @CustomerCode, CustomerName = @CustomerName, MachineName = @MachineName WHERE CustomerID = @CustomerID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Add parameters for the SQL query
                            cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                            cmd.Parameters.AddWithValue("@CustomerName", newCustomerName);
                            cmd.Parameters.AddWithValue("@MachineName", MachineName);
                            cmd.Parameters.AddWithValue("@CustomerID", id);

                            // Execute the update command
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were affected
                            if (rowsAffected > 0)
                            {
                                isSuccess = true;
                                message = "Customer update successfully";

                                SuccessConsoleColor(message, isSuccess);
                                Console.Beep();

                                Customer.DisplayAll();
                            }
                            else
                            {
                                isSuccess = false;

                                message = "Update failed: Customer ID not found.";
                                SuccessConsoleColor(message, isSuccess);

                            }
                        }
                    }
                }
                else
                {
                    isSuccess = false;

                    message = "CustomerCode or CustomerName cannot be empty.";
                    SuccessConsoleColor(message, isSuccess);

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {

                   if (id > 0){

                            using (SqlConnection con = new SqlConnection(connectionString))
                            {
                                con.Open();

                                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    // Add parameters for the SQL query

                                    cmd.Parameters.AddWithValue("@CustomerID", id);

                                    // Execute the update command
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    // Check if any rows were affected
                                    if (rowsAffected > 0)
                                    {
                                        isSuccess = true;
                                        message= "Customer deleted successfully";

                                        SuccessConsoleColor(message, isSuccess);
                                        Console.Beep();

                                     Customer.DisplayAll();

                                    }
                                    else
                                    {
                                        isSuccess = false;
                                        message = "Delete failed: Customer ID not found";
                                        SuccessConsoleColor(message, isSuccess);

                                 }
                        }
                            }

                    }
                    else
                    {
                            isSuccess = false;

                            message = "Error occured during updating.";
                           SuccessConsoleColor(message, isSuccess);

                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


        }

        public static void DisplayAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("CustomerID\tCustomerCode\tCustomerName\tMachineName");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CustomerID"]}\t\t{reader["CustomerCode"]}\t\t{reader["CustomerName"]}\t\t{reader["MachineName"]}");
                }
            }
        }
         public static void SuccessConsoleColor(string message , bool isSuccess)
        {

            if (isSuccess == true)
            {

                ConsoleColor consoleColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);

                Console.ForegroundColor = consoleColor;

            }
            else
            {
                ConsoleColor consoleColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);

                Console.ForegroundColor = consoleColor;

            }
          



        }

    }
}
