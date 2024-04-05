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

        public List<Supervisor> GetSupervisor()
        {
            string query = @" SELECT a.ActivityName, a.ActivityDate, l.FirstName, l.LastName
                            FROM dbo.activity a
                            JOIN dbo.supervise s ON a.ActivityID = s.activityID
                            JOIN dbo.lecturer l ON s.lecturerID = l.LecturerID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadSupervisors(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Supervisor> GetNotSupervisor()
        {
            string query = @"SELECT  l.FirstName ,  l.LastName 
                             FROM dbo.lecturer l
                             LEFT JOIN dbo.supervise s ON l.LecturerID = s.LecturerID
                               WHERE s.LecturerID IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[0];
          
            return ReadNotSupervisors(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Supervisor> ReadSupervisors(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                   
                    firstName = dr["FirstName"].ToString(),
                    lastName = dr["LastName"].ToString(),
                    activityName = dr["ActivityName"].ToString()
                };

                supervisors.Add(supervisor);
            }
            return supervisors;
        }
        private List<Supervisor> ReadNotSupervisors(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    
                    firstName = dr["FirstName"].ToString(),
                    lastName = dr["LastName"].ToString(),
                    
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

        //public void AddSupervisor(int activityID, int lecturerID)
        //{
        //    string query = @"INSERT INTO dbo.supervise (activityID, lecturerID)
        //                     VALUES (@activityID, @lecturerID)";
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //     new SqlParameter("@activityID", activityID),
        //     new SqlParameter("@lecturerID", lecturerID)
        //    };

        //    ExecuteEditQuery(query, parameters);
        //}

        public void RemoveSupervisor(int activityID, int lecturerID)
        {
            string query = "DELETE FROM dbo.supervise WHERE activityID = @ActivityID AND lecturerID = @LecturerID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ActivityID", activityID),
            new SqlParameter("@LecturerID", lecturerID)
            };

            ExecuteEditQuery(query, parameters);
        }


    }
}
