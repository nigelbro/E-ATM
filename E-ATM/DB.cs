using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace E_ATM
{
    class DB
    {
        private MySqlConnection connection;
        private string dbHostname;
        private string dbDatabase;
        private string dbUsername;
        private string dbPassword;
        private string dbPort;


        public DB()
        {

            Initialize();

        }
        private void Initialize()
        {


            dbHostname = "localhost";
            dbDatabase = "E_ATM";
            dbUsername = "root";
            dbPassword = "Ndb103191!#!";
            dbPort = "3307";
            string connectionString;
            connectionString = "SERVER=" + dbHostname + ";" + "PORT="+dbPort+";"+ "DATABASE=" +
            dbDatabase + ";" + "UID=" + dbUsername + ";" + "PASSWORD=" + dbPassword + ";";

            connection = new MySqlConnection(connectionString);

        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                
                switch (ex.Number)
                {
                    case 0:
                        System.Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        System.Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Insert(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand queryMysql = new MySqlCommand(query, connection);
                queryMysql.ExecuteNonQuery();
                this.CloseConnection();

            }
        }

        //Update statement
        public void Update(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand queryMysql = new MySqlCommand(query, connection);
                queryMysql.ExecuteNonQuery();
                this.CloseConnection();

            }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand queryMysql = new MySqlCommand(query, connection);
                queryMysql.ExecuteNonQuery();
                this.CloseConnection();

            }
        }

        //Select statement
        public List<string>[] Select(string query)
        {
            List< string >[] list = new List< string >[3];
    list[0] = new List< string >();
    list[1] = new List< string >();
    list[2] = new List< string >();

    //Open connection
    if (this.OpenConnection() == true)
    {
        //Create Command
        MySqlCommand cmd = new MySqlCommand(query, connection);
        //Create a data reader and Execute the command
        MySqlDataReader dataReader = cmd.ExecuteReader();
        
        //Read the data and store them in the list
        while (dataReader.Read())
        {
            list[0].Add(dataReader["customer_id"] + "");
            list[1].Add(dataReader["first_name"] + "");
            list[2].Add(dataReader["last_name"] + "");
        }

        //close Data Reader
        dataReader.Close();

        //close Connection
        this.CloseConnection();

        //return list to be displayed
        return list;
    }
    else
    {
        return list;
    }
        }

        //Count statement
        public void Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

    }




}
