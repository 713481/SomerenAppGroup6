using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class SupervisorDao : BaseDao
    {
      
        public List<Supervisor> GetNotSupervisor(Supervisor activity)
        {
            string query = "SELECT DISTINCT s.LecturerId, lecturer.FirstName, lecturer.LastName " +
               "FROM supervise AS s " +
               "JOIN lecturer ON s.LecturerId = lecturer.LecturerId " +
               "JOIN activity ON activity.ActivityId = s.ActivityId " +
               "WHERE s.LecturerId NOT IN (" +
               "    SELECT s.LecturerId FROM s WHERE ActivityID = @ActivityId)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.ActivityID);
            return ReadSupervisors(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Supervisor> GetSupervisor(Supervisor activity)
        {
            string query = "SELECT s.lecturerID, lecturer.FirstName, lecturer.LastName FROM supervise AS s " +
               "JOIN lecturer ON s.lecturerID = lecturer.LecturerID " +
               "JOIN activity ON activity.ActivityID = s.ActivityID WHERE s.ActivityID = @ActivityID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.ActivityID);
            return ReadSupervisors(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Supervisor> ReadSupervisors(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    LecturerID = (int)dr["LecturerId"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                };

                supervisors.Add(supervisor);
            }
            return supervisors;
        }

        public List<Supervisor> GetSupervisorActivities()
        {
            string query = "SELECT ActivityID, ActivityName, ActivityDate FROM [activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadActivities(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Supervisor> ReadActivities(DataTable dataTable)
        {
            List<Supervisor> activities = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor activity = new Supervisor()
                {
                    ActivityID = (int)dr["ActivityID"],
                    activityName = dr["ActivityName"].ToString(),
                    Date = (DateTime)dr["ActivityDate"]
                };
                activities.Add(activity);
            }
            return activities;
        }

        public void AddSupervisor(Supervisor activity)
        {
            string query = "INSERT INTO supervise(lecturerID,activityID) VALUES (@lecturerID, @activityID)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lecturerID", activity.LecturerID);
            sqlParameters[1] = new SqlParameter("@activityID", activity.ActivityID);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void RemoveSupervisor(Supervisor supervisor)
        {
            string query = "DELETE FROM supervise WHERE lecturerID=@lecturerID AND activityId=@activityID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lecturerId", supervisor.LecturerID);
            sqlParameters[1] = new SqlParameter("@activityId", supervisor.ActivityID);
            ExecuteEditQuery(query, sqlParameters);
        }


    }
}
