using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Dnevnik
{
    internal class DataBase:DbContext
    {
        public static string sqlstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\School.mdf;Integrated Security=True;Connect Timeout=30";
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlstr);
        }
        static public void AddTeacher(string name, string subject)
        {
            using(DataBase db = new())
            {
                Teacher teacher = new()
                {
                    Name = name,
                    Subject = subject
                };
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
        }
        static public void RemoveTeacher(int id)
        {
            using(DataBase db = new())
            {
                Teacher teacher = db.Teachers.FirstOrDefault(el => el.Id == id);
                db.Teachers.Remove(teacher);
                db.SaveChanges();
            }
        }
        static public void AddGrade(int studentid, string subject, int value)
        {
            using(DataBase db = new())
            {
                Grade grade = new()
                {
                    StudentId = studentid,
                    Subject = subject,
                    Value = value
                };
                db.Grades.Add(grade);
                db.SaveChanges();
            }
        }
        static public void RemoveGrade(int id)
        {
            using(DataBase db = new())
            {
                Grade grade = db.Grades.FirstOrDefault(el => el.Id == id);
                db.Grades.Remove(grade);
                db.SaveChanges();
            }
        }
        static public void AddStudent(string name, string _class)
        {
            using(DataBase db = new())
            {
                Student student = new()
                {
                    Name = name,
                    Class = _class
                };
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        static public void RemoveStudent(int id)
        {
            using(DataBase db = new())
            {
                Student student = db.Students.FirstOrDefault(el => el.Id == id);
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
        static public void AddShedule(string day, string time, string subject)
        {
            using(DataBase db = new())
            {
                Shedule shedule = new()
                {
                    Day = day,
                    Time = time,
                    Subject = subject
                };
                db.Shedules.Add(shedule);
                db.SaveChanges();
            }
        }
        static public void RemoveShedule(int id)
        {
            using(DataBase db = new())
            {
                Shedule shedule = db.Shedules.FirstOrDefault(el => el.Id == id);
                db.Shedules.Remove(shedule);
                db.SaveChanges();
            }
        }
    }
}
