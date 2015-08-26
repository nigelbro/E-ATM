using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_ATM;
namespace E_ATM
{
    class AtmTransaction
    {
        static void Main()
        {
            string first_name;
            string last_name;
            string addressOne;
            string addressTwo;
            string tel;
            string customerStatus;
            
            Customer customer = new Customer();
            System.Console.WriteLine("Hello are you an exisiting customer?: ");
            customerStatus = System.Console.ReadLine();
            customerStatus.ToUpper();
            //Check if customer answered with correct response
            if (customerStatus == "N" ||  customerStatus == "NO") //customer already has an account lets pull their information
            {
                customer.GetCustomerInfo();

            }else if(customerStatus == "Y" || customerStatus == "YES"){//customer is a new customer create a new account

                System.Console.WriteLine("Hello Please enter your first name ");
                first_name = System.Console.ReadLine();
                System.Console.WriteLine("Please enter your last name");
                last_name = System.Console.ReadLine();
                System.Console.WriteLine("Please enter your address one");
                addressOne = System.Console.ReadLine();
                System.Console.WriteLine("Please enter your address two");
                addressTwo = System.Console.ReadLine();
                System.Console.WriteLine("Please enter your telephone number");
                tel = System.Console.ReadLine();
                customer.SetCustomerInfo(first_name, last_name, addressOne, "", tel);

            }
            else
            {
                System.Console.WriteLine("Sorry please enter you entered a invalid entry please enter yes or no for your selection. Are you an existing customer?: ");
                customerStatus = System.Console.ReadLine();
                customerStatus.ToUpper();

            }
            
            System.Console.ReadLine();
            


        }

    }
     
}
