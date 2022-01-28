using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DBDemo3.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public int? ParkingSlotsId { get; set; }

        static string connString = "data source=.\\; initial catalog = Parking2; persist security info = True; Integrated Security = True;";

        public static List<Models.Car> GetAllCars()
        {
            var sql = "SELECT * FROM Cars";
            var cars = new List<Models.Car>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                cars = connection.Query<Models.Car>(sql).ToList();
            }
            return cars;
        }
        public static int InsertCar(Models.Car car)
        {
            int affectedRows = 0;

            var sql = $"insert into Cars(Plate, Make, Color) values ('{car.Plate}', '{car.Make}', '{car.Color}')";

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
