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
using MetroFramework;
using MySql.Data.MySqlClient;

namespace Marathon.Sponsors
{
    public partial class AddSponsors : MetroFramework.Forms.MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2021, 3, 20);
        public int a = 0;
        public string name;
        public AddSponsors()
        {
            string role = "R";
            string runn;
            string mail;
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            metroTextBoxCharitySum.Text = "0";
            timer1.Start();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");
            connection.Open();
            MySqlCommand user = new MySqlCommand("SELECT Email, FirstName, LastName FROM user WHERE RoleId =\"" + role + "\"", connection);
            MySqlDataReader reader = user.ExecuteReader();
            while (reader.Read())
            {
                mail = reader.GetString("Email");
                name = reader.GetString("FirstName");
                name = name + " " + reader.GetString("LastName");
            }
            connection.Close();
            /*MySqlConnection connection1 = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");
            connection1.Open();
            MySqlCommand run = new MySqlCommand("SELECT RunnerId, Email, CountryCode FROM runner", connection1);
            MySqlDataReader readerrun = run.ExecuteReader();
            /* while (readerrun.Read())
             {
                 runn = readerrun.GetString("RunnerId") + " " + reader.GetString("CountryCode");
                 name = name + runn;
             }*/
            metroComboBoxRunner.Items.Add(name);
            //connection1.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Sponsors.CharityInfo ci = new Sponsors.CharityInfo();
            ci.Show();
        }

        private void metroButtonPlus_Click(object sender, EventArgs e)
        {
            if (metroTextBoxCharitySum.Text != "")
            {
                a = Convert.ToInt32(metroTextBoxCharitySum.Text);
                a = a + 10;
                metroTextBoxCharitySum.Text = Convert.ToString(a);
            }
            else
            {
                metroTextBoxCharitySum.Text = "0";
                a = Convert.ToInt32(metroTextBoxCharitySum.Text);
                a = a + 10;
                metroTextBoxCharitySum.Text = Convert.ToString(a);
            }
        }

        private void metroTextBoxCharitySum_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxCharitySum.Text != "")
            {
                a = Convert.ToInt32(metroTextBoxCharitySum.Text);
            }
           
        }

        private void metroTextBoxCharitySum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void metroButtonMinus_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(metroTextBoxCharitySum.Text);
            if (metroTextBoxCharitySum.Text != "" && a > 9)
            {
                a = a - 10;
                metroTextBoxCharitySum.Text = Convert.ToString(a);
            }
            else
            {
                metroTextBoxCharitySum.Text = "10";
                a = Convert.ToInt32(metroTextBoxCharitySum.Text);
                a = a - 10;
                metroTextBoxCharitySum.Text = Convert.ToString(a);
            }
        }
    }
}
