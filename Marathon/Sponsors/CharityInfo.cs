using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Marathon.Sponsors
{
    public partial class CharityInfo : MetroFramework.Forms.MetroForm
    {
        public CharityInfo()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");
            connection.Open();
            string sql = "SELECT CharityName FROM charity WHERE CharityId = 2";
            MySqlCommand command = new MySqlCommand(sql, connection);
            string name = command.ExecuteScalar().ToString();
            label1.Text = name;
            sql = "SELECT CharityDescription FROM charity WHERE CharityId = 2";
            MySqlCommand com = new MySqlCommand(sql, connection);
            string description = com.ExecuteScalar().ToString();
            label2.Text = description;
            connection.Close();
        }
    }
}
