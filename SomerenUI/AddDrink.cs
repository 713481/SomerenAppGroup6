using SomerenDAL;
using SomerenModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SomerenUI
{
    public partial class AddDrink : Form
    {
        private readonly DrinkDao drinkDao;
        public AddDrink()
        {
            InitializeComponent();
            drinkDao = new DrinkDao();
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                string type = rbtnAlcoholic.Checked ? "Alcoholic" : "SoftDrink";

                // Create a new Drink object with the form data
                Drink newDrink = new Drink
                {
                    Id = int.Parse(tbxDrinkId.Text),
                    DrinkName = tbxDrinkName.Text,
                    Price = float.Parse(tbxPrice.Text),
                    Vat = int.Parse(tbxVat.Text),
                    Stock = int.Parse(tbxStock.Text),
                    TypeDrink = type
                };

                // Call the InsertDrink method from DrinkDao to add the new drink
                drinkDao.InsertDrink(newDrink);

                // Display a success message to the user
                MessageBox.Show("Drink added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong while adding the drinks: {ex}");
            }
            Close();
        }
    }
}
