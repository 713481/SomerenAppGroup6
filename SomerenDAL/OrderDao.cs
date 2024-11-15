﻿using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class OrderDao : BaseDao
    {
        public List<Order> GetAllOrder()
        {
            string query = "SELECT StudentID, FirstName, LastName FROM student" + "SELECT DrinkID, Price, Name, Sold, TypeDrink FROM drink";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }


        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                {
                    order.drinkID = (int)dr["StudentID"];
                    order.studentID = (int)dr["DrinkID"];
                    order.orderDateTime = DateTime.Parse(dr["DateTime"].ToString());
                }
                orders.Add(order);
            }
            return orders;
        }

        public void DrinkOrder(Order order, int countOrder, int studentId)
        {
            string query = "INSERT INTO [order] (DateTime, price, drinkid, studentID, CountOrder) VALUES (@DateTime, @Price, @DrinkID, @StudentID, @countOrder)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
               new SqlParameter("@DateTime", DateTime.Now),
               new SqlParameter("@Price", order.price),
               new SqlParameter("@DrinkID", order.drinkID),
               new SqlParameter("@StudentID", order.studentID),
               new SqlParameter("@countOrder", countOrder)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public Drink GetDrinkById(int drinkId)
        {
            string query = "SELECT DrinkID, Name, Price, Stock FROM drink WHERE DrinkID = @DrinkID";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@DrinkID", drinkId)
            };

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Drink drink = new Drink
                {
                    Id = Convert.ToInt32(row["DrinkID"]),
                    DrinkName = row["Name"].ToString(),
                    Price = Convert.ToSingle(row["Price"]),
                    Stock = Convert.ToInt32(row["Stock"]) // Add the Stock property
                };
                return drink;
            }
            return null;
        }

        public void UpdateDrinkStock(int drinkID, int quantity)
        {
            // Define your SQL query to update the stock amount
            string query = "UPDATE drink SET Stock = Stock - @Quantity WHERE DrinkID = @DrinkID";

            // Provide parameters for the query
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@Quantity", quantity),
        new SqlParameter("@DrinkID", drinkID)
            };

            // Execute the query to update the stock amount
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
