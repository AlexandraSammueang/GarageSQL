using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DBDemo3.Models
{
    public class ParkCar
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }



        static string connString = "data source=.\\; initial catalog = Parking2; persist security info = True; Integrated Security = True;";

        public static List<ParkCar> ParkYourCar(string parkingSpotId, string carId)
        {
            try
            {
                Convert.ToInt32(parkingSpotId);
                Convert.ToInt32(carId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var cars = new List<ParkCar>();
            var sql = $"UPDATE Cars SET ParkingSlotsId ={parkingSpotId} WHERE Id ={carId}";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                cars = connection.Query<ParkCar>(sql).ToList();
            }

            return cars;
        }


        public static List<Models.ParkCar> GetAllCars2()
        {
            var sql = "SELECT * FROM Cars";
            var cars2 = new List<Models.ParkCar>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                cars2 = connection.Query<Models.ParkCar>(sql).ToList();
            }
            return cars2;
        }

        public static void ParkACar()
        {
            Console.WriteLine("Välj en bil att parkera: ");
            var cars3 = ParkCar.GetAllCars2();
            foreach (var cars33 in cars3)
            {
                Console.WriteLine($"{cars33.Id} \t {cars33.Make}\t {cars33.Plate}");
            }
            Console.WriteLine();
            string carNr = Console.ReadLine();

            try
            {
                Convert.ToInt32(carNr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Välj ett garage att parkera i: ");
            var garage = ParkingHouses.GetAllParkingHouses();
            foreach (var gar in garage)
            {
                Console.WriteLine($"{gar.Id} \t {gar.HouseName}");
            }
            Console.WriteLine();

            ParkingMethods.FindEmptyParkingSpot();

            string chosenParkingSpotNr = Console.ReadLine();
            try
            {
                Convert.ToInt32(chosenParkingSpotNr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ParkYourCar(chosenParkingSpotNr, carNr);
        }

        public static List<Models.ParkCar> RemoveCar()
        {
            var sql = @"SELECT

                   c.CityName,
                   CAR.Id,
                   CAR.Plate,
                   ph.HouseName,
                   STRING_AGG(CAST(ps.SlotNumber AS nvarchar(10)), ', ') AS 'Upptagna platser'
              FROM
                   Cities c
              JOIN
                   ParkingHouses ph ON ph.CityId = c.Id
              JOIN
                   ParkingSlots ps ON ph.Id = ps.ParkingHouseId
         LEFT JOIN
                   Cars car ON ps.Id = car.ParkingSlotsId
         WHERE
                car.ParkingSlotsId IS NOT NULL
        GROUP BY
               ph.HouseName, c.CityName, car.Color, car.Plate, car.Id";

            var RCar = new List<Models.ParkCar>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                RCar = connection.Query<Models.ParkCar>(sql).ToList();
            }
            return RCar;
        }


    }
}
