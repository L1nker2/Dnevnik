using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeachersForm f = new();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentsForm f = new();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SchedulesForm f = new();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GradesForm f = new();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал студент группы 404-ИС\nКозаченко Евгений");
        }
    }
}
