using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Customer()
        {

            firstName = null;
            lastName = null;
            addressOne = null;
            addressTwo = null;
            telephoneNumber = null;

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
            db.Insert(sql);

        }
        public string[] GetCustomerInfo(){
            string[] customerInfo = new string[] { firstName, lastName, addressOne, addressTwo, telephoneNumber };
            return customerInfo;
        }

    }
   
}
