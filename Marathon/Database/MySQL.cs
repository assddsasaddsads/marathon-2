using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Database
{
    public class MySQL
    {
       static public MySqlConnection connection = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");
    }
}
