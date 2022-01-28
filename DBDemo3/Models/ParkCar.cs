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
            string carNumber = Console.ReadLine();

            try
            {
                Convert.ToInt32(carNumber);

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
            string garageNr = Console.ReadLine();

            try
            {
                Convert.ToInt32(carNumber);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Välj 1 ledig plats att parkera på");
            var emptySlots = new List<ParkCar>();
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
             car.ParkingSlotsId IS NULL";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                emptySlots = connection.Query<ParkCar>(sql).ToList();
            }
            foreach (var empty in emptySlots)
            {
                Console.WriteLine($"{empty.Id}");
            }



        }





        //static string connString = "data source=.\\; initial catalog = Parking2; persist security info = True; Integrated Security = True;";
        //public static int ParkCars(int carId, int spotId)
        //{
        //    int affectedRows = 0;
        //    var sql = $"update Cars set ParkingSlotsId = {spotId} where Id = {carId}";
        //    using (var connection = new SqlConnection(connString))
        //    {
        //        affectedRows = connection.Execute(sql);
        //    }
        //    return affectedRows;
        //}

    }
}
