using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DBDemo3.Models
{
    class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        static string connString = "data source=.\\; initial catalog = Parking2; persist security info = True; Integrated Security = True;";

        public static List<Models.City> GetAllCity()
        {
            var sql = "SELECT * FROM Cities";
            var city = new List<Models.City>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                city = connection.Query<Models.City>(sql).ToList();
            }
            return city;
        }
        public static int InsertCity(Models.City cities)
        {
            int affectedRows = 0;

            var sql = $"insert into Cities(CityName) values ('{cities.CityName}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
    }
}
