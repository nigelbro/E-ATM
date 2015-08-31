using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using E_ATM;
namespace E_ATM
{
    class Customer
    {
        private string firstName;
        private string lastName;
        private string addressOne;
        private string addressTwo;
        private string telephoneNumber;
        private string custid;
        private string acctid;
        public Customer()
        {

            firstName = null;
            lastName = null;
            addressOne = null;
            addressTwo = null;
            telephoneNumber = null;

        }
        private string CustomerInput(string response)
        {
            Regex regex = new Regex(@"\b(CHECKING|C|SAVINGS|S|BOTH|B)\b");
            if(regex.Match(response).Success)
            //if (response == "CHECKING" || response == "C" || response == "SAVINGS" || response == "S" || response == "BOTH" || response == "B") //customer already has an account lets pull their information
            {
                return response;

            }
            else
            {
                System.Console.WriteLine("Sorry please enter you entered a invalid entry please enter checking, savings, both, or (c,s,b) for your selection. What account would you like to open today?: ");
                response = System.Console.ReadLine();
                response.ToUpper();
                response = CustomerInput(response);
                return response;

            }

        }

        public void SetCustomerInfo(string fName, string lName, string address1, string address2, string tel)
        {

            this.firstName = fName;
            this.lastName = lName;
            this.addressOne = address1;
            this.addressTwo = address2;
            this.telephoneNumber = tel;
            CreateNewCustomer();
        }
        private void CreateNewCustomer()
        {
            DB db = new DB();
            string sql = "INSERT INTO Customers(first_name,last_name,address1,tel) VALUES ('"+firstName+"','"+lastName+"','"+addressOne+"','"+telephoneNumber+"') ";
            this.custid = db.Insert(sql);
            CreateNewCustomerAccount();

        }
        private void CreateNewCustomerAccount()
        {
            string accountOptions;
            Random rng = new Random();
            string acctNum ="";
            int count = 0;
            while (count != 16)
            {
             acctNum = acctNum + rng.Next(1, 9).ToString();
                count+=1;
            }
           
            DB db = new DB();
            string sql;
              sql =  "INSERT INTO Accounts(account_num,account_pin) VALUES ('" + acctNum + "', null) ";
             this.acctid =  db.Insert(sql);
             sql = null;
             sql = "UPDATE  Customers SET account_id = '"+acctid+"' WHERE customer_id = '"+custid+"' ";
             db.Update(sql);
            Console.WriteLine("Your account has successfully been created, would you like to create a checking or savings account or both today?");
            
            accountOptions = Console.ReadLine();
            accountOptions.ToUpper();
            accountOptions = CustomerInput(accountOptions);

            if (accountOptions == "CHECKING" || accountOptions == "C")
            {
                CreateChecking();
            }
            else if(accountOptions == "SAVINGS" || accountOptions == "S")
            {
                CreateSavings();
            }
            else
            {
                Console.WriteLine("Ok we will open your checking account first and then we will open your savings account");
                CreateChecking();
                CreateSavings();

            }
        }

        private void CreateChecking()
        {
            double depositAmt;
            Console.WriteLine("How much would you like to start your opening deposit? The minimum opening deposit is $50.00...");
            depositAmt = Double.Parse(Console.ReadLine());

            DB db = new DB();
            string sql = "INSERT INTO Checking(account_id,customer_id,account_balance) VALUES ('" + acctid + "','" + custid + "','" + depositAmt + "') ";
            db.Insert(sql);


        }

        private void CreateSavings()
        {

            double depositAmt;
            Console.WriteLine("How much would you like to start your opening deposit? The minimum opening deposit is $10.00...");
            depositAmt = Double.Parse(Console.ReadLine());

            DB db = new DB();
            string sql = "INSERT INTO Savings(account_id,customer_id,account_balance) VALUES ('" + acctid + "','" + custid + "','" + depositAmt + "') ";
            db.Insert(sql);


        }
        private string[] GetCustomerInfo(){
            string[] customerInfo = new string[] { firstName, lastName, addressOne, addressTwo, telephoneNumber };
            return customerInfo;
        }

    }
   
}
