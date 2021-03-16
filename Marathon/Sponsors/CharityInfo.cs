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
using Marathon.Database;

namespace Marathon.Sponsors
{
    public partial class CharityInfo : MetroFramework.Forms.MetroForm
    {
        public CharityInfo()
        {
            InitializeComponent();
            MySqlConnection connection = MySQL.connection;//необходимая команда MySql
            connection.Open();//необходимая команда MySql
            MySqlCommand chart = new MySqlCommand("SELECT CharityName, CharityDescription FROM charity WHERE CharityId =\"" + AddSponsors.charity + "\"  ", connection);
            MySqlDataReader chartreader = chart.ExecuteReader();
            while (chartreader.Read())
            {
                metroLabel1.Text = chartreader.GetString("CharityName");
                metroLabel2.Text = chartreader.GetString("CharityDescription");
            }
            connection.Close();
        }
    }
}
