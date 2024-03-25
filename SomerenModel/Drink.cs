using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        public int Id { get; set; } // drink ID
        public int Vat { get; set; } // VAT for drinks
        public float Price { get; set; } // Price for drinks
        public string DrinkName { get; set; } // Drink name
        public int Stock { get; set; } // Stock number
        public int Sold { get; set; } // Number of drinks sold
        public string TypeDrink {  get; set; } // Get the type of drink Alcoholic Softdrink etc.

    }
}
