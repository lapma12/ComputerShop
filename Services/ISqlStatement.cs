using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Services
{
    internal interface ISqlStatement
    {
        ICollection<object> GetAllData();
        object GetData(string username, string password);

        void InsertData(string username,string email,string fullname,string password);
    }
}
