using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using SomerenDAL;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            // ...

            // show dashboard
            pnlDashboard.Show();
        }
        private void ShowLecturersPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlDrinks.Hide();

            // ...

            // show students
            pnlLecturers.Show();


            try
            {
                // get and display all students
                List<Teacher> lecturers = GetLecturers();
                DisplayLecturers(lecturers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }
        // show the drink panel
        private void ShowDrinksPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlLecturers.Hide();

            // show drinks
            pnlDrinks.Show();

            try
            {
                List<Drink> drinks = GetDrinks();
                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }
        }

        private List<Teacher> GetLecturers()
        {
            LecturerService lecturerService = new LecturerService();
            List<Teacher> lecturers = lecturerService.GetLecturers();
            return lecturers;
        }
        private void DisplayLecturers(List<Teacher> lecturers)
        {
            listViewStudents.Items.Clear();

            foreach (Teacher lecturer in lecturers)
            {
                ListViewItem lvItem = CreateListViewItem(lecturer);
                listviewLecturers.Items.Add(lvItem);
            }
        }
        private ListViewItem CreateListViewItem(Teacher lecturer)
        {
            // Creates new listviewitem and add the data to the columns
            ListViewItem li = new ListViewItem(lecturer.FirstName);
            li.SubItems.Add(lecturer.LastName);
            li.SubItems.Add(lecturer.PhoneNumber.ToString());
            li.SubItems.Add(lecturer.PhoneNumber.ToString());
            li.SubItems.Add(lecturer.RoomID.ToString());
            li.Tag = lecturer;   // link student object to listview item
            return li;
        }

        // Show the student panel
        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            // ...

            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }
        //Grabs the drinks from DB
        private List<Drink> GetDrinks()
        {
            DrinkService drinkService = new DrinkService();
            List<Drink> drinks = drinkService.GetDrinks();
            return drinks;
        }
        //Grabs the listview and displays the drinks
        private void DisplayDrinks(List<Drink> drinks)
        {
            listViewDrinks.Items.Clear();

            foreach (Drink drink in drinks)
            {
                ListViewItem lvItem = CreateListViewItem(drink);
                listViewDrinks.Items.Add(lvItem);
                if (drink.Stock < 10)
                {
                    lvItem.SubItems.Add($"Stock nearly depleted");
                }
                else
                {
                    lvItem.SubItems.Add($"Stock sufficient");
                }
            }
        }
        // Create the listviewitem for the drinks
        private ListViewItem CreateListViewItem(Drink drink)
        {
            // Creates new listviewitem and add the data to the columns
            ListViewItem li = new ListViewItem(drink.Id.ToString());
            li.SubItems.Add(drink.DrinkName);
            li.SubItems.Add(drink.TypeDrink);
            li.SubItems.Add(drink.Price.ToString("0.00"));
            li.SubItems.Add(drink.Vat.ToString());
            li.SubItems.Add(drink.Stock.ToString());
            li.SubItems.Add(drink.Sold.ToString());
            li.Tag = drink;
            return li;
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private void DisplayStudents(List<Student> students)
        {
            listViewStudents.Items.Clear();

            foreach (Student student in students)
            {
                ListViewItem lvItem = CreateListViewItem(student);
                listViewStudents.Items.Add(lvItem);
            }
        }

        private ListViewItem CreateListViewItem(Student student)
        {
            // Creates new listviewitem and add the data to the columns
            ListViewItem li = new ListViewItem(student.FirstName);
            li.SubItems.Add(student.LastName);
            li.SubItems.Add(student.PhoneNumber.ToString());
            li.SubItems.Add(student.Number.ToString());
            li.SubItems.Add(student.Class.ToString());
            li.Tag = student;   // link student object to listview item
            return li;
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturersPanel();
        }

        private void pnlLecturers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinksPanel();
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            AddDrink form = new AddDrink();
            if (form.ShowDialog() == DialogResult.OK) // Show AddDrink form as dialog
            {
                RefreshDrinks(); // Refresh the ListView after the AddDrink form is closed
            }
        }

        private void btnRemoveDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an item is selected in the ListView
                if (listViewDrinks.SelectedItems.Count > 0)
                {
                    // Get the selected drink from the ListView
                    Drink selectedDrink = (Drink)listViewDrinks.SelectedItems[0].Tag;

                    // Display a confirmation message box
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this drink?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user confirms the deletion, proceed with deleting the drink
                    if (result == DialogResult.Yes)
                    {
                        // Call the DAO method to delete the drink
                        DrinkDao drinkDao = new DrinkDao();
                        drinkDao.DeleteDrink(selectedDrink.Id);

                        // Refresh the drinks list
                        RefreshDrinks();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a drink to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting drink: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDrink_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count > 0)
            {
                // Get the selected drink from the ListView
                Drink selectedDrink = (Drink)listViewDrinks.SelectedItems[0].Tag;

                // Open a new form or dialog to edit the drink details
                EditDrink editForm = new EditDrink(selectedDrink, this); // Pass SomerenUI instance as parameter
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a drink to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RefreshDrinks()
        {
            try
            {
                // Get and display all drinks
                List<Drink> drinks = GetDrinks();
                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }
        }
    }
}