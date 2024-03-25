using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT DrinkID, VAT, Price, Stock, Name, Sold, TypeDrink FROM drink ORDER BY Name";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink newdrink = new Drink()
                {
                    Id = (int)dr["DrinkID"],
                    DrinkName = dr["Name"].ToString(),
                    TypeDrink = dr["TypeDrink"].ToString(),
                    Price = float.Parse(dr["Price"].ToString()),
                    Vat = (int)dr["VAT"],
                    Stock = (int)dr["Stock"],
                    Sold = Convert.IsDBNull(dr["Sold"]) ? 0 : Convert.ToInt32(dr["Sold"])
                };
                drinks.Add(newdrink);
            }
            return drinks;
        }
        public void InsertDrink(Drink drink)
        {
            string query = "INSERT INTO drink (DrinkID, Name, Price, Stock, VAT, TypeDrink) VALUES (@DrinkId, @Name, @Price, @Stock, @VAT, @TypeDrink)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkId", drink.Id),
                new SqlParameter("@Name", drink.DrinkName),
                new SqlParameter("@Price", drink.Price),
                new SqlParameter("@VAT", drink.Vat),
                new SqlParameter("@Stock", drink.Stock),
                new SqlParameter("@TypeDrink", drink.TypeDrink)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
        public void DeleteDrink(int drinkId)
        {
            string query = "DELETE FROM drink WHERE DrinkID = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
        new SqlParameter("@DrinkId", drinkId)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
        public void UpdateDrink(Drink drink)
        {
            string query = "UPDATE drink SET Name = @Name, Price = @Price, VAT = @VAT, Stock = @Stock, TypeDrink = @TypeDrink WHERE DrinkID = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Name", drink.DrinkName),
                new SqlParameter("@Price", drink.Price),
                new SqlParameter("@VAT", drink.Vat),
                new SqlParameter("@Stock", drink.Stock),
                new SqlParameter("@TypeDrink", drink.TypeDrink),
                new SqlParameter("@DrinkId", drink.Id)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
