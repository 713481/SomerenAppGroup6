using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class RevenueReportService
    {

        private RevenueReportDao revenueReportdb;

        public RevenueReportService()
        {
            revenueReportdb = new RevenueReportDao();
        }

        public List<RevenueReport> GetRevenueReports(DateTime startDate, DateTime endDate)
        {
            List<RevenueReport> revenueReports = revenueReportdb.GetAllRevenueReport(startDate, endDate);
            return revenueReports;
        }
    }
}
