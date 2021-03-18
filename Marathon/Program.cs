using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Marathon
{
    static class Program
    {
        public static MySqlConnection connection = new MySqlConnection("server=" +
             "141.8.192.58;" +
             "user=a0523665_tesss;" +
             "database=a0523665_newTester;" +
             "password=02022002");
        public static User userInfo = new User();
        public static MySqlDataReader sqlDataReader = null;
        public static string companyName = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen());
        }
    }
}
