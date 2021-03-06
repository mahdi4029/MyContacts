using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Repository
{
    public interface IContacts
    {
        DataTable GetAll();
        bool AddPerson(string name, string family, string age, string mobile, string address);
        bool Delete(int contactId);
        DataTable Select(int contactId);
        bool Edit(int contactId,string name,string family,string age,string mobile,string address);
        DataTable Search(string parameter);
    }
}
