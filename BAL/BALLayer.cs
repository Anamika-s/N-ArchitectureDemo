using DTO;
using DAL;
namespace BAL
{
    public class BALLayer
    {
        DAL.DALLAyer dALLAyer = new DALLAyer();
        public int AddStudent(Student student)
        {
            dALLAyer.AddStudent(student);
            return 1;
        }

        public int UpdateStudent(int rn, Student student)
        {
            return dALLAyer.UpdateStudent(rn, student);
        }

        public int DeleteStudent(int rn)
        {
            return dALLAyer.DeleteStudent(rn);
        }
        public Student GetStudentById(int rn)
        {
            return dALLAyer.GetStudentById(rn);
        }

        public List<Student> GetStudents()
        {
            return dALLAyer.GetStudents();
        }

    }
}
