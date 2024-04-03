using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;
using System;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = "SELECT StudentID, FirstName, LastName, PhoneNumber, Age, Class, RoomID FROM Student";
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
                    Class = dr["Class"].ToString(),
                    Room = (int)dr["RoomID"]
                };
                students.Add(student);
            }
            return students;
        }
        public void InsertStudent(Student student)
        {
            string query = "INSERT INTO student (StudentID, FirstName, LastName, PhoneNumber, Age, Class, RoomID) VALUES (@Id, @FirstName, @LastName, @PhoneNumber, @Age, @Class, @RoomId)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", student.Id),
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Age", student.Age),
                new SqlParameter("@Class", student.Class),
                new SqlParameter("@RoomId", student.Room)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
        public void DeleteStudent(int studentId)
        {
            try
            {
                string query = "DELETE FROM student WHERE StudentID = @StudentId";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@StudentId", studentId)
                };

                ExecuteEditQuery(query, sqlParameters);

                // No exception occurred, deletion successful
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation error number
                {
                    // Handle foreign key constraint violation
                    throw new Exception("This student is referenced by other records and cannot be deleted.");
                }
                else
                {
                    // Handle other SQL exceptions
                    throw new Exception($"Error deleting student: {ex.Message}");
                }
            }
        }
        public void UpdateStudent(Student student)
        {
            string query = "UPDATE student SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Age = @Age, Class = @Class, RoomID = @RoomId WHERE StudentID = @StudentId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Age", student.Age),
                new SqlParameter("@Class", student.Class),
                new SqlParameter("@RoomId", student.Room), // Assuming Room corresponds to RoomID in the Room table
                new SqlParameter("@StudentId", student.Number) // Assuming StudentID corresponds to the Number property of the Student class
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}