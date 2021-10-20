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
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@address", address);
                command.ExecuteNonQuery();
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

        public bool Delete(int contactId)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = Select(contactId);
                if ((int)dataTable.Rows[0][0]==contactId)
                {
                    string query = $"delete from MyContacts where ContactId={contactId}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }

                return false;
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

        public DataTable Select(int contactId)
        {
            string query = $"select * from MyContacts where ContactId={contactId}";
            DataTable dataTable = new DataTable();
            return FillAdapter(query, dataTable);

        }

        public bool Edit(int contactId)
        {
            try
            {
                string query =
                    $"update MyContacts set Name=@name, Family=@family, Age=@age, Mobile=@mobile, Address=@address where ContactId={contactId}";
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
