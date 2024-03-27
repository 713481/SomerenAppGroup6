using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = "SELECT StudentID, FirstName, LastName, PhoneNumber, Age, Class FROM Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Number = (int)dr["StudentID"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    PhoneNumber = (int)dr["PhoneNumber"],
                    Age = (int)dr["Age"],
                    Class = dr["Class"].ToString()
                };
                students.Add(student);
            }
            return students;
        }
        public void InsertStudent(Student student)
        {
            string query = "INSERT INTO student (FirstName, LastName, PhoneNumber, Age, Class, RoomID) VALUES (@FirstName, @LastName, @PhoneNumber, @Age, @Class, @RoomId)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Age", student.Age),
                new SqlParameter("@Class", student.Class),
                new SqlParameter("@RoomId", student.Room)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}