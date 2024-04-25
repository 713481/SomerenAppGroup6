using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class StudentParticipationDao : BaseDao
    {
        public List<StudentParticipation> GetAllParticipatingStudents()
        {
            string query = "SELECT participant.studentID, activity.ActivityID, activity.ActivityName, student.FirstName, student.LastName " +
               "FROM participant " +
               "JOIN student ON participant.studentID = student.StudentID " +
               "JOIN activity ON activity.ActivityID = participant.activityID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<StudentParticipation> ReadTables(DataTable dataTable)
        {
            List<StudentParticipation> students = new List<StudentParticipation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                StudentParticipation student = new StudentParticipation()
                {
                    studentID = (int)dr["studentId"],
                    activityID = (int)dr["ActivityId"],
                    activityName = dr["ActivityName"].ToString(),
                    firstName = dr["FirstName"].ToString(),
                    lastName = dr["LastName"].ToString()
                };
                students.Add(student);
            }
            return students;
        }

        public List<StudentParticipation> GetNonParticipatingStudents()
        {
            string query = "SELECT s.StudentID, s.FirstName, s.LastName " +
                           "FROM student s " +
                           "WHERE NOT EXISTS (SELECT 1 FROM participant p WHERE p.studentID = s.StudentID)";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadGetNon(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<StudentParticipation> ReadGetNon(DataTable dataTable)
        {
            List<StudentParticipation> students = new List<StudentParticipation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                StudentParticipation student = new StudentParticipation()
                {
                    studentID = (int)dr["StudentID"],
                    firstName = dr["FirstName"].ToString(),
                    lastName = dr["LastName"].ToString()
                };
                students.Add(student);
            }
            return students;
        }

        public void AddStudentParticipant(int studentID, int activityID)
        {
            string query = "INSERT INTO participant (studentID, activityID) VALUES (@StudentID, @ActivityID)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@StudentID", studentID),
        new SqlParameter("@ActivityID", activityID)
            };

            ExecuteEditQuery(query, parameters);
        }

        public void RemoveStudentParticipant(int studentID, int activityID)
        {
            string query = "DELETE FROM participant WHERE studentID = @StudentID AND activityID = @ActivityID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@StudentID", studentID),
            new SqlParameter("@ActivityID", activityID)
            };

            ExecuteEditQuery(query, parameters);
        }

        public List<StudentParticipation> GetParticipatingStudents(int activityID)
        {
            string query = "SELECT participant.ParticipantID, participant.studentID, activity.ActivityName, student.FirstName, student.LastName " +
         "FROM participant " +
         "JOIN student ON participant.studentID = student.StudentID " +
         "JOIN activity ON participant.activityID = activity.ActivityID " +
         "WHERE activity.ActivityID = @ActivityID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@ActivityID", activityID)
            };

            return ReadTablesNonParticipation(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<StudentParticipation> ReadTablesNonParticipation(DataTable dataTable)
        {
            List<StudentParticipation> students = new List<StudentParticipation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                StudentParticipation student = new StudentParticipation()
                {
                    participationID = (int)dr["ParticipantID"],
                    studentID = (int)dr["studentId"],
                    activityName = dr["ActivityName"].ToString(),
                    firstName = dr["FirstName"].ToString(),
                    lastName = dr["LastName"].ToString()
                };
                students.Add(student);
            }
            return students;
        }
    }
}
