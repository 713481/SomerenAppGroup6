using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class StudentParticipation
    {
        public int activityID { get; set; }
        public int studentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string activityName { get; set; }

        public int participationID { get; set; }
    }
}
