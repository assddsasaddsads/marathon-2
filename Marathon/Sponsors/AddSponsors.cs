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
        public AddSponsors()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            metroTextBoxCharitySum.Text = "0";
            timer1.Start();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");
            connection.Open();
            MySqlCommand newcommand = new MySqlCommand("SELECT DISTINCT CountryCode FROM country", connection);
            MySqlDataReader reader = newcommand.ExecuteReader();
           /* while (reader.Read())
            {
                metroComboBox1.Items.Add(reader.GetString("CountryCode"));
            }*/
            connection.Close();
            /*metroComboBox1.Text = "RUS";
            metroComboBox2.Text = "Бегун";*/
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
    }
}
