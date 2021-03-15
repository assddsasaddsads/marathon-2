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
        public string Id,Id2;
        public string Sum;
        public static int value,charity;
        public AddSponsors()
        {
            string role = "R";
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            metroTextBoxCharitySum.Text = "0";
            timer1.Start();
            MySqlConnection connection = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");//необходимая команда MySql
            MySqlConnection connection1 = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");//необходимая команда MySql
            connection.Open();//необходимая команда MySql
            connection1.Open();//необходимая команда MySql
           
            MySqlCommand user = new MySqlCommand("SELECT FirstName, LastName FROM user WHERE RoleId =\"" + role + "\"  ", connection);//вытаскиваем имена по RoleId = R 
            MySqlDataReader reader = user.ExecuteReader();//команда для выборки данных из таблицы сonnection
            MySqlCommand runner = new MySqlCommand("SELECT RunnerId, CountryCode FROM runner", connection1);//вытаскиваем RunnerId и CountryCode
            MySqlDataReader runnerreader = runner.ExecuteReader();//команда для выборки данных из таблицы сonnection1

            while (reader.Read()&& runnerreader.Read())
            {
                name = reader.GetString("FirstName") + " " + reader.GetString("LastName") ;//name становится именем и фамилией бегуна 
                Id = runnerreader.GetString("RunnerId") + " " + runnerreader.GetString("CountryCode");//Id становится RunnerId и CountryCode-ом
                Sum = name + " " + Id;//склеиваем их
                metroComboBoxRunner.Items.Add(Sum);//добавляем склейку в комбобокс
            }
            connection.Close();//необходимая команда MySql
            connection1.Close();//необходимая команда MySql
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
                labelBigNums.Text ="$" + metroTextBoxCharitySum.Text;
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

        private void metroComboBoxRunner_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroLabelCharityName.Text = metroComboBoxRunner.SelectedItem.ToString();
            string a = metroComboBoxRunner.SelectedItem.ToString();
            int.TryParse(string.Join("", a.Where(c => char.IsDigit(c))), out value);
            MySqlConnection connection2 = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");//необходимая команда MySql
            MySqlConnection connection3 = new MySqlConnection("server=localhost;database=marathon;user=root;password=lox123");//необходимая команда MySql
            connection2.Open();//необходимая команда MySql
            connection3.Open();//необходимая команда MySql
            MySqlCommand runner2 = new MySqlCommand("SELECT CharityId FROM registration WHERE RunnerId =\"" + value + "\"  ", connection2);
            MySqlDataReader runnerreader2 = runner2.ExecuteReader();
            while (runnerreader2.Read())
            {
                charity = Convert.ToInt32(runnerreader2.GetString("CharityId"));
            }
            MySqlCommand chart = new MySqlCommand("SELECT CharityName FROM charity WHERE CharityId =\"" + charity + "\"  ", connection3);
            MySqlDataReader chartreader = chart.ExecuteReader();
            while (chartreader.Read())
            {
                metroLabelCharityName.Text = chartreader.GetString("CharityName");
            }

            connection2.Close();//необходимая команда MySql
            connection3.Close();//необходимая команда MySql
        }
    }
}
