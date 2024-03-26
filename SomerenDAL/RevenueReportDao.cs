﻿using System;
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
                 "SUM(CountOrder) AS Sales, " +
                "SUM(CountOrder * (Price + (Price * VAT))) AS Turnover, COUNT(DISTINCT StudentID) AS NumberOfCustomers " +
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
                    Turnover = (int)dr["Turnover"],
                    NumberOfCustomers = (int)dr["NUmberOfCustomer"]
                };
                revenueReports.Add(revenueReport);
            }
            return revenueReports;
        }
    }
}
