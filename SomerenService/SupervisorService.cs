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
        public List<Supervisor> GetNotSupervisors(Supervisor activity)
        {
            List<Supervisor> supervisors = supervisordb.GetNotSupervisor(activity);
            return supervisors;
        }
        public List<Supervisor> GetSupervisors(Supervisor activity)
        {
            List<Supervisor> supervisors = supervisordb.GetSupervisor(activity);
            return supervisors;
        }

        public List<Supervisor> GetAllSupervisedActivities()
        {
            List<Supervisor> activities = supervisordb.GetSupervisorActivities();
            return activities;
        }
        public void AddSupervisors(Supervisor activity)
        {
            supervisordb.AddSupervisor(activity);
        }
        public void RemoveSupervisors(Supervisor activity)
        {
            supervisordb.RemoveSupervisor(activity);
        }
    }
}
