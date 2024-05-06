using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Order
    {
        public int drinkID { get; set; }
        public int studentID { get; set; }
        public float price { get; set; }
        public DateTime orderDateTime { get; set; }
        public int sales { get; set; }

    }
}
