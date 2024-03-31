using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class StudentParticipationService
    {
        private StudentParticipationDao participationdb;

        public StudentParticipationService()
        {
            // new LecturerDao from LecturerDao lecturerdb
            participationdb = new StudentParticipationDao();
        }

        public List<StudentParticipation> GetStudentParticipations()
        {
            List<StudentParticipation> participations = participationdb.GetAllParticipatingStudents();
            return participations;
        }

        public List<StudentParticipation> GetNonStudentParticipation()
        {
            List<StudentParticipation> nonParticipation = participationdb.GetNonParticipatingStudents();
            return nonParticipation;
        }

        public void AddStudentParticipant(int studentID, int activityID)
        {
            participationdb.AddStudentParticipant(studentID, activityID);
        }

        public void RemoveStudentParticipant(int studentID, int activityID)
        {
            participationdb.RemoveStudentParticipant(studentID, activityID);
        }
    }
}
