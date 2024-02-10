using System.Data;

namespace Dnevnik
{
    public partial class TeachersForm : Form
    {
        public TeachersForm()
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
                var teachers = db.Teachers.ToList();
                DataTable dt = new();
                dt.Columns.Add("Айди");
                dt.Columns.Add("ФИО");
                dt.Columns.Add("Предмет");
                foreach (var teacher in teachers)
                {
                    dt.Rows.Add(teacher.Id, teacher.Name, teacher.Subject);
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
            dataGridView1.Size = new(982, 489);
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
            DataBase.RemoveTeacher(id);
            MessageBox.Show("Удаление прошло успешно");
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string subject = textBox1.Text;
            if(name == "" && subject == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            DataBase.AddTeacher(name, subject);
            MessageBox.Show("Добавление прошло успешно");
            panel1.Visible = false;
            dataGridView1.Size = new(982, 639);
            LoadData();
        }
    }
}
