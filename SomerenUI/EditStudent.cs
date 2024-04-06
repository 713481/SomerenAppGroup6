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
    public partial class EditStudent : Form
    {
        private Student selectedStudent;
        private SomerenUI parentForm;

        public EditStudent(Student student, SomerenUI parentForm)
        {
            InitializeComponent();
            selectedStudent = student;
            this.parentForm = parentForm; // Store reference to SomerenUI form
        }

        private void btnStudentEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the selected student object with the edited values
                selectedStudent.FirstName = tbxStudentFirstName.Text;
                selectedStudent.LastName = tbxStudentLastName.Text;
                selectedStudent.PhoneNumber = int.Parse(tbxStudentPhoneNumber.Text);
                selectedStudent.Age = int.Parse(tbxStudentAge.Text);
                selectedStudent.Class = tbxStudentClass.Text;
                selectedStudent.Room = int.Parse(tbxStudentRoomId.Text); // Update room ID

                // Call the DAO method to update the student in the database
                StudentDao studentDao = new StudentDao();
                studentDao.UpdateStudent(selectedStudent);

                // Inform the user that the update was successful
                MessageBox.Show("Student information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh students list on parent form
                parentForm.RefreshStudents();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {
            // Populate the form fields with the details of the selected student
            tbxStudentId.Text = selectedStudent.Number.ToString();
            tbxStudentFirstName.Text = selectedStudent.FirstName;
            tbxStudentLastName.Text = selectedStudent.LastName;
            tbxStudentPhoneNumber.Text = selectedStudent.PhoneNumber.ToString();
            tbxStudentAge.Text = selectedStudent.Age.ToString();
            tbxStudentClass.Text = selectedStudent.Class;
            tbxStudentRoomId.Text = selectedStudent.Room.ToString();
        }
    }
}
