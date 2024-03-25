using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SomerenUI
{
    public partial class EditDrink : Form
    {
        private Drink selectedDrink;
        private SomerenUI parentForm;

        public event EventHandler DrinkUpdated;
        public EditDrink(Drink drink, SomerenUI parentForm)
        {
            InitializeComponent();
            selectedDrink = drink;
            this.parentForm = parentForm; // Store reference to SomerenUI form
        }
        private void EditDrink_Load_1(object sender, EventArgs e)
        {
            // Populate the form fields with the details of the selected drink
            tbxDrinkId.Text = selectedDrink.Id.ToString();
            tbxDrinkName.Text = selectedDrink.DrinkName;
            tbxPrice.Text = selectedDrink.Price.ToString("0.00");
            tbxVat.Text = selectedDrink.Vat.ToString();
            tbxStock.Text = selectedDrink.Stock.ToString();
            if (selectedDrink.TypeDrink == "Alcoholic")
            {
                rbtnAlcoholic.Checked = true;
            }
            else
            {
                rbtnSoftDrink.Checked = true;
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the selected drink object with the edited values
                selectedDrink.DrinkName = tbxDrinkName.Text;
                selectedDrink.Price = float.Parse(tbxPrice.Text);
                selectedDrink.Vat = int.Parse(tbxVat.Text);
                selectedDrink.Stock = int.Parse(tbxStock.Text);
                selectedDrink.TypeDrink = rbtnAlcoholic.Checked ? "Alcoholic" : "SoftDrink";

                // Call the DAO method to update the drink in the database
                DrinkDao drinkDao = new DrinkDao();
                drinkDao.UpdateDrink(selectedDrink);

                // Inform the user that the update was successful
                MessageBox.Show("Drink information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh drinks list on parent form
                parentForm.RefreshDrinks();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating drink information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
