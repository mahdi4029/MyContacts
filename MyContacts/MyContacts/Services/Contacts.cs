using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyContacts.Repository
{
    public class Contacts : IContacts
    {
        private static string connectionsString = "Data Source=.;Initial Catalog=MyContact_DB;Integrated Security=true";
        private SqlConnection connection = new SqlConnection(connectionsString);
        public DataTable GetAll()
        {
            string query = "select * from MyContacts";
            DataTable allContacts = new DataTable();
            return FillAdapter(query, allContacts);

        }

        public bool AddPerson(string name, string family, string age, string mobile, string address)
        {
            try
            {
                string query =
                    "insert into MyContacts (Name,Family,Age,Mobile,Address) values (@name,@family,@age,@mobile,@address)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue(@name, name);
                command.Parameters.AddWithValue(@family, family);
                command.Parameters.AddWithValue(@age, age);
                command.Parameters.AddWithValue(@mobile, mobile);
                command.Parameters.AddWithValue(@address, address);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        DataTable FillAdapter(string query, DataTable dataTable)
        {
            var adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
