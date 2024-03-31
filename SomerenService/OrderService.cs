using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void OrderDrink(Order order, int countOrder, int studentid)
        {
            orderdb.DrinkOrder(order, countOrder, studentid);
        }
        public Drink GetDrinkById(int drinkId)
        {
            return orderdb.GetDrinkById(drinkId);
        }

        public void UpdateDrinkStock(int drinkID, int quantity)
        {
            // Call the appropriate method in your Data Access Layer (DAL) to update the stock amount
            // You will need to implement this method in your DAL
            orderdb.UpdateDrinkStock(drinkID, quantity);
        }

    }
}
