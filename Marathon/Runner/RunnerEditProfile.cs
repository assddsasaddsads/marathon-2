using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marathon.Database;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Marathon.Runner
{
    public partial class RunnerEditProfile : MetroForm
    {
        string image;
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2021, 3, 20);
        string login;
        public RunnerEditProfile(string data)
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            timer1.Start();
            MySqlConnection connection = new MySqlConnection(MySQL.connectionUrl);
            connection.Open();
            MySqlCommand newcommand = new MySqlCommand("SELECT DISTINCT CountryCode FROM country", connection);
            MySqlDataReader reader = newcommand.ExecuteReader();
            while (reader.Read())
            {
                metroComboBox1.Items.Add(reader.GetString("CountryCode"));
            }
            connection.Close();
            login = data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(metroTextBox2.Text, @"^((?=.*?[A-Z])(?=.*?[0-9])(?=.*?[# ! @ $ % ^]))"))
            {
                if (metroTextBox4.Text.Length != 0 && metroTextBox5.Text.Length != 0 && metroDateTime1.Text.Length != 0 && metroComboBox1.Text.Length != 0)
                {
                    if (metroTextBox2.Text.Length >= 6)
                    {
                        if (metroTextBox2.Text == metroTextBox3.Text)
                        {
                            MySqlConnection connection = new MySqlConnection(MySQL.connectionUrl);
                            connection.Open();
                            MySqlCommand command = new MySqlCommand("UPDATE user SET Password = @password, FirstName = @firstname, LastName = @lastname WHERE Email = @login", connection);
                            command.Parameters.AddWithValue("@login", login);
                            command.Parameters.AddWithValue("@password", metroTextBox2.Text);
                            command.Parameters.AddWithValue("@firstname", metroTextBox4.Text);
                            command.Parameters.AddWithValue("@lastname", metroTextBox5.Text);
                            command.Prepare();
                            command.ExecuteNonQuery();
                            connection.Close();
                            connection.Open();
                            var gender = "";
                            if (metroRadioButton1.Checked)
                            {
                                gender = "Male";
                            }
                            else
                            {
                                gender = "Female";
                            }
                            MySqlCommand command1 = new MySqlCommand("UPDATE runner SET Gender = @gender,DateOfBirth = @dateOfBirth,CountryCode = @countryCode, image = @image WHERE Email = @login", connection);
                            command1.Parameters.AddWithValue("@login", login);
                            command1.Parameters.AddWithValue("@gender", gender);
                            command1.Parameters.AddWithValue("@dateOfBirth", metroDateTime1.Value);
                            command1.Parameters.AddWithValue("@countryCode", metroComboBox1.Text);
                            command1.Parameters.AddWithValue("@image", image);
                            command1.Prepare();
                            command1.ExecuteNonQuery();
                            connection.Close();
                            MetroMessageBox.Show(this, "Данные успешно изменены!");
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Введенные пароли не совпадают!");
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Введённый пароль слишком короткий!");
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Один из параметров не введён!");
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Пароль не подходит к требованиям!");
            }
        }

        private void metroTextBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (e.KeyChar == 33 || e.KeyChar == 35 || e.KeyChar == 64 || e.KeyChar == 36 || e.KeyChar == 94)
            {
                e.Handled = true;
            }
        }

        private void metroTextBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 33 || e.KeyChar == 35 || e.KeyChar == 64 || e.KeyChar == 36 || e.KeyChar == 94)
            {
                e.Handled = true;
            }
        }

        private void metroTextBox4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
            {
                e.Handled = true;
            }
        }

        private void metroTextBox5_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
            {
                e.Handled = true;
            }
            
        }
        private void RunnerEditProfile_Load(object sender, EventArgs e)
        {

        }
        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }

        private Random _random = new Random(Environment.TickCount);
        public string RandomString(int length)
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }
        private void metroButton3_Click(object sender, EventArgs e)
        { 
            if (image != null)
            {
                File.Delete(image);
            }
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string newFileName = RandomString(10) + ".jpg";
                var bit = new Bitmap(ofd.FileName);
                pictureBox2.Image = bit;
                metroTextBox6.Text = ofd.FileName;
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string path = ofd.FileName;
                string newPath = directory + newFileName;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                    image = newFileName;
                    // альтернатива с помощью класса File
                    // File.Copy(path, newPath, true);
                }
            }
        }
    }
}
