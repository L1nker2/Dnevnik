using System.Data;

namespace Dnevnik
{
    public partial class SchedulesForm : Form
    {
        public SchedulesForm()
        {
            InitializeComponent();
            panel1.Visible = false;
            dataGridView1.Size = new(982, 639);
            LoadData();
        }
        void LoadData()
        {
            using (DataBase db = new())
            {
                var shedules = db.Shedules.ToList();
                DataTable dt = new();
                dt.Columns.Add("Айди");
                dt.Columns.Add("День");
                dt.Columns.Add("Время");
                dt.Columns.Add("Предмет");
                foreach (var shedule in shedules)
                {
                    dt.Rows.Add(shedule.Id, shedule.Day, shedule.Time, shedule.Subject);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Size = new(982, 427);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Необходимо выбрать запись");
                return;
            }
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int.TryParse(row.Cells["Айди"].Value.ToString(), out int id);
            DataBase.RemoveShedule(id);
            MessageBox.Show("Удаление прошло успешно");
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string day = textBox3.Text;
            string time = textBox2.Text;
            string subject = textBox1.Text;
            if (day == "" && time == "" && subject == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            DataBase.AddShedule(day, time, subject);
            MessageBox.Show("Добавление прошло успешно");
            panel1.Visible = false;
            dataGridView1.Size = new(982, 639);
            LoadData();
        }
    }
}
