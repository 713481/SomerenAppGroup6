using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddStudent : Form
    {
        private readonly StudentDao studentDao;
        public AddStudent()
        {
            InitializeComponent();
            studentDao = new StudentDao();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
        }

        private void lblStudentAge_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentRoomId_Click(object sender, EventArgs e)
        {

        }

        private void btnStudentAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new Student object with the form data
                Student student = new Student
                {
                    Id = int.Parse(tbxStudentId.Text),
                    FirstName = tbxStudentFirstName.Text,
                    LastName = tbxStudentLastName.Text,
                    PhoneNumber = int.Parse(tbxStudentPhoneNumber.Text),
                    Age = int.Parse(tbxStudentAge.Text),
                    Class = (tbxStudentClass.Text),
                    Room = int.Parse(tbxStudentRoomId.Text),
                };

                // Call the Student method from StudentDao to add the new student
                studentDao.InsertStudent(student);

                // Display a success message to the user
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while adding the student: {ex}");
            }
            Close();
        }
    }
}
