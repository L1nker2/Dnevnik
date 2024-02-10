using System.Data;

namespace Dnevnik
{
    public partial class GradesForm : Form
    {
        public GradesForm()
        {
            InitializeComponent();
            panel1.Visible = false;
            dataGridView1.Size = new(982, 639);
            LoadData();
            LoadContext();
        }
        void LoadContext()
        {
            using (DataBase db = new())
            {
                var students = db.Students.ToList();
                foreach (var student in students)
                {
                    comboBox1.Items.Add(student.Name);
                }
            }
        }
        void LoadData()
        {
            using (DataBase db = new())
            {
                var grades = db.Grades.ToList();
                DataTable dt = new();
                dt.Columns.Add("Айди");
                dt.Columns.Add("Студент");
                dt.Columns.Add("Предмет");
                dt.Columns.Add("Оценка");
                foreach (var grade in grades)
                {
                    Student student = db.Students.FirstOrDefault(el => el.Id == grade.StudentId);
                    dt.Rows.Add(grade.Id, student.Name, grade.Subject, grade.Value);
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
            DataBase.RemoveGrade(id);
            MessageBox.Show("Удаление прошло успешно");
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = comboBox1.SelectedItem.ToString();
            string subject = textBox2.Text;
            string value = textBox1.Text;
            if(name == "" && subject == "" && value == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            using(DataBase db = new())
            {
                Student student = db.Students.FirstOrDefault(el => el.Name == name);
                if(int.TryParse(value, out int grade))
                {
                    DataBase.AddGrade(student.Id, subject, grade);
                    MessageBox.Show("Добавление прошло успешно");
                    panel1.Visible = false;
                    dataGridView1.Size = new(982, 639);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Оценка должна быть числового типа данных!!!");
                    return;
                }
            }
        }
    }
}