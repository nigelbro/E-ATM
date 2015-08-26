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
            Customer customer = new Customer();
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
            customer.SetCustomerInfo(first_name, last_name, addressOne, "",tel);
            System.Console.ReadLine();
            


        }

    }
     
}
