using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class DALLAyer
    {
        SqlConnection connection;
        SqlCommand command;

        public string GetConnectionString()
        {
            return @"server=ANAMIKA\SQLSERVER;database=wiproDb;integrated security=true";
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public int AddStudent(Student student)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("insert into student(rn,name,batch,score,doj)" +
                "values(@rn,@name,@batch,@score,@doj)", connection);
            command.Parameters.AddWithValue("@rn", student.Rn);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@batch", student.Batch);
            command.Parameters.AddWithValue("@score", student.Score);
            command.Parameters.AddWithValue("@doj", student.Doj);
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return 1;
        }
        public int UpdateStudent(int rn, Student student)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("update student set batch=@batch,score=@score where " +
                "rn=@rn", connection);
            command.Parameters.AddWithValue("@rn", student.Rn);
            command.Parameters.AddWithValue("@batch", student.Batch);
            command.Parameters.AddWithValue("@score", student.Score);
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return 1;
        }

        public int DeleteStudent(int rn)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("delete student where rn=@rn", connection);
            command.Parameters.AddWithValue("@rn", rn);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return 1;
        }

        public Student GetStudentById(int rn)
        {
            Student student = null;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from student where rn=@rn", connection);
            command.Parameters.AddWithValue("@rn", rn);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                student = new Student()
                {
                    Rn = (int)reader[0],
                    Name = reader[1].ToString(),
                    Batch = reader[2].ToString(),
                    Score = (int)reader[3],
                    Doj = Convert.ToDateTime(reader[4])
                };
            }

            connection.Close();
            return student;


        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>() ;
            Student student;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from student", connection);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student = new Student()
                    {
                        Rn = (int)reader[0],
                        Name = reader[1].ToString(),
                        Batch = reader[2].ToString(),
                        Score = (int)reader[3],
                        Doj = Convert.ToDateTime(reader[4])
                    };
                    students.Add(student);
                }
            }
            connection.Close();
                return students;
            }
        }
    }
