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
            HideAllPanel();

            // ...

            // show dashboard
            pnlDashboard.Show();
        }
        private void HideAllPanel()
        {
            pnlStudents.Hide();
            pnlLecturers.Hide();
            pnlDrinks.Hide();
            pnlRoom.Hide();
            pnlReport.Hide();
            pnlDashboard.Hide();
            pnldrinkorder.Hide();
            pnlParticipant.Hide();
            pnlSupervisorActivity.Hide();
        }

        // show the drink panel
        private void ShowDrinksPanel()
        {
            // hide all other panels
            HideAllPanel();

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
        //----------------------------------lecturer--------------------------------------
        private void ShowLecturersPanel()
        {
            // hide all other panels
            HideAllPanel();
            // show lecturer
            pnlLecturers.Show();


            try
            {
                // get and display all lecturer
                List<Teacher> lecturers = GetLecturers();
                DisplayLecturers(lecturers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the lecturer: " + e.Message);
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
            listviewLecturers.Items.Clear();

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
            li.SubItems.Add(lecturer.Age.ToString());
            li.SubItems.Add(lecturer.RoomID.ToString());
            li.Tag = lecturer;   // link lecturer object to listview item
            return li;
        }

        // Show the student panel
        private void ShowStudentsPanel()
        {
            // hide all other panels
            HideAllPanel();
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
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent form = new AddStudent();
            if (form.ShowDialog() == DialogResult.OK) // Show AddDrink form as dialog
            {
                RefreshStudents(); // Refresh the ListView after the AddDrink form is closed
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
            ListViewItem li = new ListViewItem(student.Number.ToString());
            li.SubItems.Add(student.FirstName);
            li.SubItems.Add(student.LastName);
            li.SubItems.Add(student.PhoneNumber.ToString());
            li.SubItems.Add(student.Age.ToString());
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
        public void RefreshStudents()
        {
            try
            {
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void ShowRoomPanel()
        {
            //hide other panel
            HideAllPanel();

            //show room panel
            pnlRoom.Show();

            try
            {
                // get and display all students
                List<Room> rooms = GetRooms();
                DisplayRoom(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the Room: " + e.Message);
            }
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.GetRooms();
            return rooms;
        }

        private void DisplayRoom(List<Room> rooms)
        {
            // clear the listview before filling it
            /*listViewStudents.Clear();*/

            listViewOfRoom.Items.Clear();
            //listViewStudents.Columns.Clear();
            //listViewStudents.View = View.Details;
            //AddStudentColumns();

            foreach (Room room in rooms)
            {
                ListViewItem lvItem = CreateListViewItemForRoom(room);
                listViewOfRoom.Items.Add(lvItem);
            }
        }

        private ListViewItem CreateListViewItemForRoom(Room room)
        {
            // Creates new listviewitem and add the data to the columns
            ListViewItem li = new ListViewItem(room.RoomID.ToString()); // Convert to string
            li.SubItems.Add(room.Capacity.ToString()); // Convert to string
            li.SubItems.Add(room.Floor.ToString()); // Convert to string
            li.SubItems.Add(room.Building.ToString()); // Convert char to string
            li.SubItems.Add(room.Type.ToString()); // Convert char to string
            li.Tag = room;   // link room object to listview item
            return li;
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomPanel();
        }
        //------------------Revenue Report------------------------------------
        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRevenueReportPanel();
        }
        private void ShowRevenueReportPanel()
        {
            // hide all other panels
            HideAllPanel();
            // show revenue report
            pnlReport.Show();



        }
        private List<RevenueReport> GetRevenueReports(DateTime startDate, DateTime endDate)
        {
            RevenueReportService revenueReportService = new RevenueReportService();

            List<RevenueReport> revenueReports = revenueReportService.GetRevenueReports(startDate, endDate);
            return revenueReports;
        }
        private void DisplayRevenueReports(List<RevenueReport> revenueReports)
        {
            listViewRevenueReports.Items.Clear();

            foreach (RevenueReport revenueReport in revenueReports)
            {
                ListViewItem lvItem = CreateListViewItem(revenueReport);
                listViewRevenueReports.Items.Add(lvItem);
            }
        }
        private ListViewItem CreateListViewItem(RevenueReport revenueReport)
        {
            // Creates new listviewitem and add the data to the columns
            ListViewItem li = new ListViewItem(revenueReport.DrinkName.ToString());
            li.SubItems.Add(revenueReport.Sales.ToString());
            li.SubItems.Add(revenueReport.Turnover.ToString("C"));
            li.SubItems.Add(revenueReport.NumberOfCustomers.ToString());
            li.Tag = revenueReport;   // link revenue report object to listview item
            return li;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //assigned datepicker to thier assignment value
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            //invalid
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (endDate > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("End date cannot end in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((endDate - startDate).Days < 1)
            {
                MessageBox.Show("PLease have a range date of atleast one to proceed.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            List<RevenueReport> revenueReports = GetRevenueReports(startDate, endDate);
            DisplayRevenueReports(revenueReports);
        }

        //===================================================Order

        private void DisplayDrinkingOrder(List<Student> students, List<Drink> drinks)
        {
            listViewdrinkorder.Items.Clear();

            foreach (var drink in drinks)
            {
                ListViewItem list = new ListViewItem(drink.Id.ToString());
                list.Tag = drink;
                list.SubItems.Add(drink.DrinkName.ToString());
                list.SubItems.Add(drink.Price.ToString());
                list.SubItems.Add(drink.TypeDrink.ToString());
                list.SubItems.Add(drink.Stock.ToString());
                listViewdrinkorder.Items.Add(list);
            }

            listviewnamesstudent.Items.Clear();

            foreach (var student in students)
            {
                ListViewItem list = new ListViewItem(student.Number.ToString());
                list.Tag = student;
                list.SubItems.Add(student.FirstName.ToString());
                list.SubItems.Add(student.LastName.ToString());
                listviewnamesstudent.Items.Add(list);
            }
        }

        private void ShowDrinkOrderPanel()
        {
            HideAllPanel();

            pnldrinkorder.Show();
            try
            {
                // getting the students form the GetStudents method and sending it to the list and then displaying in cash register
                List<Student> students = GetStudents();
                List<Drink> drink = GetDrinks();
                DisplayDrinkingOrder(students, drink);
            }
            catch (Exception e)
            {
                // show error message box if there is an error
                MessageBox.Show("There is something wrong happen while order drink" + e.Message);
            }
        }
        private List<Student> listOfstudents;
        private List<Drink> listOfdrinks;
        private OrderService orderService = new OrderService();

        private void btncheckout_Click(object sender, EventArgs e)
        {
            if (listviewnamesstudent.SelectedItems == null || listviewnamesstudent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select your student.");
                return;
            }

            if (listViewdrinkorder.SelectedItems == null || listViewdrinkorder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a drink.");
                return;
            }

            int studentID = int.Parse(listviewnamesstudent.SelectedItems[0].SubItems[0].Text);
            int drinkID = int.Parse(listViewdrinkorder.SelectedItems[0].SubItems[0].Text);

            Order order = new Order();
            order.studentID = studentID;
            order.drinkID = drinkID;

            string input = txtTotalAmount.Text;
            int numberOfDrink;
            if (!int.TryParse(input, out numberOfDrink))
            {
                MessageBox.Show("You entered an invalid quantity.");
                return;
            }

            Drink selectedDrink = orderService.GetDrinkById(drinkID); // You need to implement this method

            if (selectedDrink == null)
            {
                MessageBox.Show("Unable to retrieve selected drink.");
                return;
            }

            // Calculate the total cost using the retrieved drink's price
            float priceTotal = selectedDrink.Price * numberOfDrink;

            // Update the order with the calculated total cost
            order.price = priceTotal;

            // Call the orderService to place the order
            orderService.OrderDrink(order, numberOfDrink, studentID);

            orderService.UpdateDrinkStock(drinkID, numberOfDrink); // You need to implement this method

            // Show the success message with the total cost
            MessageBox.Show($"Order placed successfully. Total Price: {priceTotal}");

            // UnselectListviewItem(listviewnamesstudent);
            // UnselectListviewItem(listviewnamesstudent);
        }

        private int numberOfORder = 0;
        private int KeepTrackOrderID()
        {
            numberOfORder++;
            return numberOfORder;
        }

        private void drinkOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinkOrderPanel();
        }


        //=========================================================> Participation
        private void ShowParticipationPanel()
        {
            HideAllPanel();

            pnlParticipant.Show();

            try
            {
                List<StudentParticipation> getParticipant = GetParticipation();
                List<StudentParticipation> notParticipation = GetNonParticipation();
                DisplayStudentParticipant(getParticipant, notParticipation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void DisplayStudentParticipant(List<StudentParticipation> participations, List<StudentParticipation> nonParticipations)
        {
            listViewParticipant.Items.Clear();
            foreach (var participent in participations)
            {
                ListViewItem list = new ListViewItem(participent.activityID.ToString());
                list.Tag = participent;
                list.SubItems.Add(participent.activityName.ToString());
                list.SubItems.Add(participent.studentID.ToString());
                list.SubItems.Add(participent.firstName.ToString());
                listViewParticipant.Items.Add(list);
            }

            listViewNotParticipation.Items.Clear();
            foreach (var nonParticipation in nonParticipations)
            {
                ListViewItem list = new ListViewItem(nonParticipation.studentID.ToString());
                list.Tag = nonParticipation;
                list.SubItems.Add(nonParticipation.firstName.ToString());
                list.SubItems.Add(nonParticipation.lastName.ToString());
                listViewNotParticipation.Items.Add(list);
            }
        }

        public void DisplayParticipation(int activityID)
        {
            try
            {
                List<StudentParticipation> participation = GetStudentParticipations(activityID);
                listViewOfParticipationSelect.Items.Clear();
                foreach (var studentParticipation in participation)
                {
                    ListViewItem list = new ListViewItem(studentParticipation.participationID.ToString());
                    list.Tag = studentParticipation;
                    list.SubItems.Add(studentParticipation.studentID.ToString());
                    list.SubItems.Add(studentParticipation.firstName.ToString());
                    list.SubItems.Add(studentParticipation.lastName.ToString());
                    list.SubItems.Add(studentParticipation.activityName.ToString());
                    listViewOfParticipationSelect.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying participation: " + ex.Message);
            }
        }

        private void ActivityListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (listViewParticipant.SelectedItems.Count > 0)
            {
                // Retrieve the selected activity ID from the ListView
                int selectedActivityID = int.Parse(listViewParticipant.SelectedItems[0].SubItems[0].Text);

                // Display the participation details for the selected activity
                DisplayParticipation(selectedActivityID);
            }
        }
        private void listViewParticipant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOfParticipationSelect.SelectedItems.Count > 0)
            {
                // Retrieve the selected activity ID from the ListView
                int selectedActivityID = int.Parse(listViewOfParticipationSelect.SelectedItems[0].SubItems[0].Text);

                // Display the participation details for the selected activity
                DisplayParticipation(selectedActivityID);
            }
        }

        private List<StudentParticipation> GetParticipation()
        {
            StudentParticipationService participationService = new StudentParticipationService();
            List<StudentParticipation> participations = participationService.GetStudentParticipations();
            return participations;
        }

        private List<StudentParticipation> GetNonParticipation()
        {
            StudentParticipationService nonParticipationService = new StudentParticipationService();
            List<StudentParticipation> participations = nonParticipationService.GetNonStudentParticipation();
            return participations;
        }

        private List<StudentParticipation> GetStudentParticipations(int activityID)
        {
            StudentParticipationService participationService = new StudentParticipationService();
            List<StudentParticipation> participations = participationService.GetParticipations(activityID);
            return participations;
        }

        private void participationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowParticipationPanel();
        }

        private void buParticipants_Click(object sender, EventArgs e)
        {
            int activityID = int.Parse(listViewParticipant.SelectedItems[0].SubItems[0].Text);

            if (activityID != null)
            {
                StudentParticipationService participationService = new StudentParticipationService();
                participationService.GetParticipations(activityID);
                DisplayParticipation(activityID);
            }
            else
            {
                MessageBox.Show("Please select both an activity and a student.");
            }
        }
        private void btbAdd_Click(object sender, EventArgs e)
        {
            if (listViewNotParticipation.SelectedItems == null || listViewNotParticipation.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select your student id");
                return;
            }

            if (listViewParticipant.SelectedItems == null || listViewParticipant.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a activity id");
                return;
            }
            int studentID = int.Parse(listViewNotParticipation.SelectedItems[0].SubItems[0].Text);
            int activityID = int.Parse(listViewParticipant.SelectedItems[0].SubItems[0].Text);

            if (activityID != null && studentID != null)
            {
                StudentParticipationService participationService = new StudentParticipationService();
                participationService.AddStudentParticipant(studentID, activityID);
                ShowParticipationPanel();
            }
            else
            {
                MessageBox.Show("Please select both an activity and a student.");
            }
        }

        private void btbRemove_Click(object sender, EventArgs e)
        {
            if (listViewParticipant.SelectedItems == null || listViewParticipant.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a participant to remove.");
                return;
            }

            int studentID = int.Parse(listViewParticipant.SelectedItems[0].SubItems[2].Text);
            int activityID = int.Parse(listViewParticipant.SelectedItems[0].SubItems[0].Text);

            DialogResult result = MessageBox.Show("Are you sure you wish to remove this participant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    StudentParticipationService participantService = new StudentParticipationService();
                    participantService.RemoveStudentParticipant(studentID, activityID);

                    // Refresh the listview to reflect the changes
                    RefreshParticipantListView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing participant: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshParticipantListView()
        {
            // Clear the existing items in the listview
            listViewParticipant.Items.Clear();

            try
            {
                // Retrieve the updated participant data from the database using your service method
                StudentParticipationService participantService = new StudentParticipationService();
                List<StudentParticipation> participants = participantService.GetStudentParticipations();

                // Populate the listview with the updated participant data
                foreach (var participant in participants)
                {
                    ListViewItem list = new ListViewItem(participant.activityID.ToString());
                    list.Tag = participant;
                    list.SubItems.Add(participant.activityName.ToString());
                    list.SubItems.Add(participant.studentID.ToString());
                    list.SubItems.Add(participant.firstName.ToString());
                    listViewParticipant.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing participant list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------Supervisor-------------------------------------------------

        public void ShowSupervisorPanel()
        {
            HideAllPanel();
            pnlSupervisorActivity.Show();


            try
            {
                DisplaySupervisorActivities();
                DisplayNotSupervisors();
                DisplaySupervisors();

            }

            catch (Exception e)
            {
                // show error message box if there is an error
                MessageBox.Show("Something went wrong while loading the supervisor page: " + e.Message);
            }


        }
        private List<Supervisor> GetSupervisedActivities()
        {
            SupervisorService supervisorsService = new SupervisorService();
            List<Supervisor> supervisors = supervisorsService.GetSupervisorActivities();
            return supervisors;
        }
        private void DisplaySupervisorActivities()
        {
            // clear the listview before filling it
            listViewActivityShow.Items.Clear();
            List<Supervisor> activities = GetSupervisedActivities();

            foreach (Supervisor activity in activities)
            {
                ListViewItem li = new ListViewItem(activity.activityName.ToString());
                li.SubItems.Add($"{activity.Date:dd/MM/yyyy}");
                li.Tag = activity;


                listViewActivityShow.Items.Add(li);
            }
        }


        private List<Supervisor> GetSupervisors()
        {
            SupervisorService supervisorsService = new SupervisorService();
            List<Supervisor> supervisors = supervisorsService.GetSupervisors();
            return supervisors;
        }
        private List<Supervisor> GetNotSupervisors()
        {
            SupervisorService supervisorsService = new SupervisorService();
            List<Supervisor> supervisors = supervisorsService.GetNotSupervisors();
            return supervisors;
        }

        private void DisplayNotSupervisors()
        {
            // clear the listview before filling it
            listViewSupervisorNot.Items.Clear();

            List<Supervisor> supervisors = GetNotSupervisors();

            foreach (Supervisor supervisor in supervisors)
            {
                ListViewItem li = new ListViewItem(supervisor.firstName.ToString());
                li.SubItems.Add(supervisor.lastName.ToString());
                li.Tag = supervisor;


                listViewSupervisorNot.Items.Add(li);
            }
        }
        private void DisplaySupervisors()
        {
            // clear the listview before filling it
            listViewSupervisorIs.Items.Clear();

            List<Supervisor> supervisors = GetSupervisors();

            foreach (Supervisor supervisor in supervisors)
            {
                ListViewItem li = new ListViewItem(supervisor.firstName.ToString());
                li.SubItems.Add(supervisor.lastName.ToString());

                li.SubItems.Add(supervisor.activityName.ToString());

                li.Tag = supervisor;
                listViewSupervisorIs.Items.Add(li);
            }
        }



        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSupervisorPanel();
        }

        private void btnAddSupervisor_Click(object sender, EventArgs e)
        {
            // select activity and lecturer from the list views
            if (listViewActivityShow.SelectedItems.Count == 0 || listViewSupervisorNot.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select both an activity and a lecturer.");
                return;
            }



        }

        private void btnRemoveSupervisor_Click(object sender, EventArgs e)
        {
            // Check if select
            if (listViewSupervisorIs.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one association between an activity and a lecturer.");
                return;
            }

            // Get the selected 
            Supervisor selectedAssociation = (Supervisor)listViewSupervisorIs.SelectedItems[0].Tag;

            // Delete
            SupervisorService supervisorService = new SupervisorService();
            supervisorService.RemoveSupervisor(selectedAssociation.ActivityID, selectedAssociation.LecturerId);

            // Refresh the ListView
            DisplaySupervisorActivities();
            DisplayNotSupervisors();
            DisplaySupervisors();
        }

        private void btnUpdateSupervisor_Click(object sender, EventArgs e)
        {
            DisplaySupervisorActivities();
            DisplayNotSupervisors();
            DisplaySupervisors();
        }

        private void listViewSupervisorNot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}