using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class SupervisorService
    {
        private SupervisorDao supervisordb;

        public SupervisorService()
        {
            supervisordb = new SupervisorDao();
        }
        public List<Supervisor> GetNotSupervisors()
        {
            List<Supervisor> supervisors = supervisordb.GetNotSupervisor();
            return supervisors;
        }
        public List<Supervisor> GetSupervisors()
        {
            List<Supervisor> supervisors = supervisordb.GetSupervisor();
            return supervisors;
        }

        public List<Supervisor> GetSupervisorActivities()
        {
            List<Supervisor> activities = supervisordb.GetSupervisorActivities();
            return activities;
        }

        //public void AddSupervisor(int activityID, int lecturerID)
        //{
        //    supervisordb.AddSupervisor(activityID, lecturerID);
        //}
        public void RemoveSupervisor(int activityID, int lecturerID)
        {
            supervisordb.RemoveSupervisor(activityID, lecturerID);
        }

    }
}
