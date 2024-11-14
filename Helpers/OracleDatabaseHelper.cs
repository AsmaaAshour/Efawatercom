using EfawatercomProject.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Helpers
{
    public class OracleDatabaseHelper
    {
        public bool IsCategoryAdded(string categoryName)
        {
            bool exists = false;
            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();
                string query = "select count(1) from billercategory where billercategoryname = :CategoryName";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("CategoryName", categoryName));
                    exists = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
            return exists;
        }


        public bool IsBillAdded(string billName)
        {
            bool exists = false;
            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();
                string query = "select count(1) from billername where billname= :BillName";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("BillName", billName));
                    exists = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
            return exists;
        }


        public List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();
            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();
                string query = "select billercategoryname from billercategory";
                using (OracleCommand command = new OracleCommand(query, connection))
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader.GetString(0));
                    }
                }
            }
            return categories;
        }


        public (int Count, int Sum, int BillerId) GetCountAndSumFromDatabase(string selectedCategoryName)
        {
            int count = 0;
            int sum = 0;
            int billerId = 0;

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                string query = @"
           SELECT COUNT(*) , 
                   SUM(paymenthistory.profits) , 
                   billername.billerid
            FROM paymenthistory
            JOIN billername ON paymenthistory.billerid = billername.billerid
            JOIN billercategory ON billername.billercategoryid = billercategory.billercategoryid
            WHERE billercategory.billercategoryname = :selectedCategoryName
            GROUP BY billername.billerid";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("selectedCategoryName", selectedCategoryName));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            count = reader.GetInt32(0);
                            sum = reader.GetInt32(1);
                            billerId = reader.GetInt32(2);
                        }
                    }
                }
            }
            return (count, sum, billerId);
        }
    }
}