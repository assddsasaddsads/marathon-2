using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

namespace Marathon.Event
{
    public partial class HowLong : MetroForm
    {
        TimeSpan d = new TimeSpan();
        DateTime date = new DateTime(2021, 3, 20);
        public HowLong()
        {
            InitializeComponent();
            this.Resizable = false;
            this.MaximizeBox = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = date - DateTime.Now;
            metroLabel1.Text = "До начала марафона осталось: " + d.Days + " д. " + d.Hours + " ч. " + d.Minutes + " мин. " + d.Seconds + " с. ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.f1_car;
            metroLabel12.Text = "Гоночный болид F1 пройдет марафон за 7 минут 20 секунд";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.worm;
            metroLabel12.Text = "Червь пройдет марафон за 58 дней 7 часов";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.sloth;
            metroLabel12.Text = "Ленивец пройдет марафон за 14 дней 12 часов";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.capybara;
            metroLabel12.Text = "Капибара пройдет марафон за 1 час 12 минут";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.jaguar;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.airbus_a380;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.pair_of_havaianas;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.football_field;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.ronaldinho;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.bus;
            metroLabel12.Text = "Ягуар пройдет марафон за 31 минуту 30 секунд";
        }
    }
}
