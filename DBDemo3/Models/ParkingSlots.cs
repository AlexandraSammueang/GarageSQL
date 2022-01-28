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
    public class ParkingSlots
    {
        static string connString = "data source =.\\; initial catalog= parking2; persist security info=true; integrated security = true;";

        public int id { get; set; }
        public int SlotNumber { get; set; }
        public bool ElectricOutlet { get; set; }
        public int ParkingHouseId { get; set; }

        public static List<ParkingSlots> GetAllParkingSlots()
        {
            var parkingSlots = new List<ParkingSlots>();
            var sql = "SELECT * FROM ParkingSlots";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                parkingSlots = connection.Query<ParkingSlots>(sql).ToList();
            }

            return parkingSlots;
        }

        public static int InsertParkingSlot(ParkingSlots parkingSlot)
        {

            int affectedRows = 0;

            var sql = $"INSERT INTO ParkingSlots(SlotNumber, ElectricOutlet, ParkingHouseId) VALUES ({parkingSlot.SlotNumber}," +
                $" '{parkingSlot.ElectricOutlet}', {parkingSlot.ParkingHouseId})";

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