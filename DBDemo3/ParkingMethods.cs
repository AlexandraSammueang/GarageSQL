using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDemo3.Models;
using System.Data.SqlClient;
using Dapper;

namespace DBDemo3
{
    public class ParkingMethods
    {
        static string connString = "data source =.\\; initial catalog= parking2; persist security info=true; integrated security = true;";

        public string LedigaPlatser { get; set; }
        public int Slot { get; set; }

        public static void ChooseParkingHouse()
        {
            Console.WriteLine("Vilken stad vill du parkera i? \n");
            var cityNames = City.GetAllCity();
            foreach (var cityName in cityNames)
            {
                Console.WriteLine($"{cityName.Id} \t {cityName.CityName}");
            }
            Console.WriteLine();
            string cityNr = Console.ReadLine();

            try
            {
                Convert.ToInt32(cityNr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Vilket garage vill du parkera i?");
            var Parkings = new List<ParkingHouses>();
            var sql = $"SELECT * FROM ParkingHouses WHERE CityId = {cityNr}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                Parkings = connection.Query<ParkingHouses>(sql).ToList();
            }
            foreach (var parkings in Parkings)
            {
                Console.WriteLine($"{parkings.Id} \t { parkings.HouseName}");
            }

            string garageNr = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Convert.ToInt32(garageNr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sql = @$"
                     SELECT
                       STRING_AGG(CAST(ps.SlotNumber AS nvarchar(10)) , ', ') AS LedigaPlatser
                    FROM
                        Cities c
                    JOIN
                         ParkingHouses ph ON ph.CityId = c.Id
                    JOIN
                         ParkingSlots ps ON ph.Id = ps.ParkingHouseId
                    LEFT JOIN
                         Cars car ON ps.Id = car.ParkingSlotsId
                    WHERE
                        car.ParkingSlotsId IS NULL and ph.CityId = {cityNr} and ph.Id = {garageNr}
                    GROUP BY
                         ph.HouseName, c.CityName";

            Console.WriteLine("Följande platser är lediga i garaget; \n");
            var emptySlots = new List<ParkingMethods>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                emptySlots = connection.Query<ParkingMethods>(sql).ToList();
            }
            foreach (var empty in emptySlots)
            {
                Console.WriteLine($"{empty.LedigaPlatser}");
            }

        }
        public static void FindEmptyParkingSpot()
        {
            string parkingHouseId = Console.ReadLine();
            try
            {
                Convert.ToInt32(parkingHouseId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var sql = $@"SELECT
                c.CityName,
                ph.HouseName,
                ps.Id AS Slot,
                ps.Id AS SlotId
            FROM
               Cities c
             JOIN
             ParkingHouses ph ON ph.CityId = c.Id
             JOIN
             ParkingSlots ps ON ph.Id = ps.ParkingHouseId
             LEFT JOIN
             Cars car ON ps.Id = car.ParkingSlotsId
             WHERE
             car.ParkingSlotsId IS NULL and ph.id = {parkingHouseId}";

            Console.WriteLine("Följande platser är lediga i garaget; \n");
            var emptySlots = new List<ParkingMethods>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                emptySlots = connection.Query<ParkingMethods>(sql).ToList();
            }
            foreach (var empty in emptySlots)
            {
                Console.WriteLine($"{empty.Slot}");
            }
            Console.WriteLine();
            Console.WriteLine("Välj en plats att parkera på");
        }

    }

}
