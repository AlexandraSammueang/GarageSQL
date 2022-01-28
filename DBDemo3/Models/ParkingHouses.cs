using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDemo3.Models;
using System.Data.SqlClient;
using Dapper;

namespace DBDemo3.Models
{
    public class ParkingHouses
    {
        static string connString = "data source =.\\; initial catalog= parking2; persist security info=true; integrated security = true;";

        public int Id { get; set; }
        public string HouseName { get; set; }
        public int CityId { get; set; }

        public static List<ParkingHouses> GetAllParkingHouses()
        {
            var ParkingHouseNames = new List<ParkingHouses>();
            var sql = "SELECT * FROM ParkingHouses";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                ParkingHouseNames = connection.Query<ParkingHouses>(sql).ToList();
            }

            return ParkingHouseNames;
        }
        public static int InsertParkingHouse(ParkingHouses phouse)
        {

            int affectedRows = 0;

            var sql = $"INSERT INTO ParkingHouses(HouseName, CityId) VALUES ('{phouse.HouseName}', {phouse.CityId})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

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