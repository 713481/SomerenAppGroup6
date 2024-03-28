using SomerenDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenService
{
    public class OrderService
    {
        private OrderDao orderdb;

        public OrderService()
        {
            orderdb = new OrderDao();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = orderdb.GetAllOrder();
            return orders;
        }

        public void OrderDrink(Order order)
        {
            orderdb.DrinkOrder(order);
        }
        public Drink GetDrinkById(int drinkId)
        {
            return orderdb.GetDrinkById(drinkId);
        }
    }
}
