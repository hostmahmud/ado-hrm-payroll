using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HRM.Classes
{
    class Connection
    {
        public static SqlConnection conn = null;
        public void DBCon() 
        {
            conn = new SqlConnection("Data Source=MAHMUDSABUJ;Initial Catalog=humanResourceManagement_DB;Integrated Security=true");
            conn.Open();
        }
        public void conClose() {
            conn.Close();
        }
    }
}
