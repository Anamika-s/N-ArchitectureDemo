using DTO;
using BAL;
namespace StudentApp
{
    internal class Program
    {
       static  BAL.BALLayer balLayer = new BAL.BALLayer();

        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                int ch = Menu();
                switch (ch)
                {
                    case 1: List<Student> students =  balLayer.GetStudents();
                        Console.WriteLine("RN\t Name \t Batch \t Score \t Date Of Joining");

                        foreach (Student student in students)
                        {
                            Console.WriteLine(student.Rn + "\t" + student.Name + "\t" + student.Batch + "\t" + student.Score + "\t" + student.Doj); ;

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("enter rn");
                            int rn = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("enter score");
                            int score = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter doj");
                            DateTime doj = DateTime.Now;
                            // Object Initializer
                            Student student = new Student()
                            {
                                Rn = rn,
                                Name = name,
                                Batch = batch,
                                Score = score,
                                Doj = doj
                            };
                            balLayer.AddStudent(student); 
                            break;
                        } 
                    case 3:
                        {
                            Console.WriteLine("enter rn for which to delete record");
                            int rn = byte.Parse(Console.ReadLine());
                            balLayer.DeleteStudent(rn);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter rn for which to edit record");
                            int rn = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter new batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("enter updated score");
                            int score = int.Parse(Console.ReadLine());
                            Student student = new Student()
                            {
                                Rn= rn,
                                Batch = batch,
                                Score = score,
                            };
                            balLayer.UpdateStudent(rn, student); break;

                        }
                    case 5:
                        {
                            Console.WriteLine("enter rn to search");
                            int rn = byte.Parse(Console.ReadLine());
                            Student student = balLayer.GetStudentById(rn);
                            Console.WriteLine(student.Rn + "\t" + student.Name + "\t" + student.Batch + "\t" + student.Score + "\t" + student.Doj); ;

                            break;
                        }
                
                    default:
                        Console.WriteLine("invalid choice"); break;
                }

                Console.WriteLine("Repeat?");
                choice = Console.ReadLine();
            }
        }

        static int Menu()
        {
            Console.WriteLine("1. Get Records");
            Console.WriteLine("2. Insert Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Edit Record");
            Console.WriteLine("5. Search Record");
            Console.WriteLine("enter your choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }

    }
}
