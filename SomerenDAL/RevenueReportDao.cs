using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenDAL
{
    public class RevenueReportDao : BaseDao
    {
        public List<RevenueReport> GetAllRevenueReport(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT Name AS DrinkName, " +
                 "SUM(o.CountOrder) AS Sales, " +
                "SUM(o.CountOrder * (d.Price + (d.Price * (VAT / 100)))) AS Turnover, COUNT(DISTINCT studentID) AS NumberOfCustomers " +
                "FROM [order] AS o JOIN drink AS d ON o.DrinkID = d.DrinkID " +
                "WHERE [DateTime] BETWEEN @StartDate AND @EndDate " +
                "GROUP BY d.Name";
            SqlParameter[] parameters = {
                new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate },
                new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate }
            };
            DataTable dataTable = ExecuteSelectQuery(query, parameters);
            return ReadTables(dataTable);
        }

        private List<RevenueReport> ReadTables(DataTable dataTable)
        {
            List<RevenueReport> revenueReports = new List<RevenueReport>();

            foreach (DataRow dr in dataTable.Rows)
            {
                RevenueReport revenueReport = new RevenueReport()
                {
                    DrinkName= dr["DrinkName"].ToString(),  
                    Sales = (int)dr["Sales"],
                    Turnover = (double)dr["Turnover"],
                    NumberOfCustomers = (int)dr["NumberOfCustomers"]
                };
                revenueReports.Add(revenueReport);
            }
            return revenueReports;
        }
    }
}
