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
    class Program
    {
        static void Main(string[] args)

        {
            
            ParkCar.ParkACar();
            //ParkingMethods.ChooseParkingHouse();

            //Console.WriteLine("Alla bilar: ");
            //var cars = DBDemo3.Models.Car.GetAllCars();

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Id}\t{car.Plate}\t{car.Make}\t{car.Color}\t{car.ParkingSlotsId}");
            //}
            //Console.WriteLine("----------------------------------------------");

            //// Lägg till ny bil
            //Random rnd = new Random();
            //var rNumber = rnd.Next(100, 999);

            //var newCar = new Models.Car
            //{
            ////    Plate = "XPW" + rNumber,
            ////    Make = "Tesla",
            ////    Color = "Röd"
            ////};
            ////int rowsAffected = DBDemo3.Models.Car.InsertCar(newCar);
            ////Console.WriteLine("Antal bilar tillagda: " + rowsAffected);
            //Console.WriteLine("----------------------------------------------");
            //Console.WriteLine("----------------------------------------------");

            ////Visa alla citys
            //Console.WriteLine("Alla städer (city): ");
            //var city = DBDemo3.Models.City.GetAllCity();

            //foreach (var City in city)
            //{
            //    Console.WriteLine($"{City.Id} \t {City.CityName}");
            //}
            //Console.WriteLine("----------------------------------------------");

            // Lägg till ny city

            //var newCity = new Models.City
            //{
            //    CityName = "Västerås"

            //};
            //int rowsAffected1 = DBDemo3.Models.City.InsertCity(newCity);
            //Console.WriteLine("Antal city tillagd: " + rowsAffected);
            //Console.WriteLine("------------------------------------------------------------------------------------");


            //Console.WriteLine("-------------------------------------------------------------------------------------");
            ////Alla parkeringshus
            //Console.WriteLine("Alla Parkeringar: ");
            //var Parkings = DBDemo3.Models.Parkings.GetAllParkings();

            //foreach (var parkings in Parkings)
            //{
            //    Console.WriteLine($"{parkings.Id}\t{parkings.CarData}\t{parkings.CityName}\t {parkings.HouseName}\t {parkings.SlotNumber}\n" +
            //    $" \t{parkings.ElectricOutlet} \n{parkings.Plate} \n{parkings.CarData}");
            //}
            //Console.WriteLine("-------------------------------------------------------------------------------------");

            //Lägg till nytt parkeringshus

            //var newParkings = new Models.ParkingHouses
            //{
            //    //CityName = "Västerås",
            //    CityId = 13,
            //    HouseName = "P-husDäcket"
            //    //SlotNumber = 8,
            //    //ElectricOutlet = true,
            //    //Plate = "AAA111",
            //    //CarData = "MiniCooper,Rosa"

            //};
            //int rowsAffected2 = DBDemo3.Models.ParkingHouses.InsertParkingHouse(newParkings);
            //Console.WriteLine("Antal parkering tillag: " + rowsAffected2);
            //Console.WriteLine("-----------------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------------");

            ////Alla parkeringar

            //Console.WriteLine("Alla Parkerings rutor: ");
            //var parkingSlot = DBDemo3.Models.ParkingSlots.GetAllParkingSlots();

            //foreach (var parkingSlots in parkingSlot)
            //{
            //    Console.WriteLine($"{parkingSlots.Id}\t{parkingSlots.SlotNumber}" +
            //        $"\t{parkingSlots.ElectricOutlet}\t{parkingSlots.ParkingHouseId}");
            //}
            //Console.WriteLine("----------------------------------------------");

            //// Lägg till ny parkering

            //var newParkingSlot = new Models.ParkingSlots { SlotNumber = 1, ElectricOutlet = true, ParkingHouseId = 25 };
            //int rowsAffected4 = Models.ParkingSlots.InsertParkingSlot(newParkingSlot);
            //Console.WriteLine("\nAntal nya parkeringsplatser tillagda: " + rowsAffected4);


            //ParkedCar
            //Console.WriteLine("Välj bil att parkera bil: ");
            //var parkedCar = DBDemo3.Models.ParkCar.GetAllCars2();

            //foreach (var Car1 in parkedCar)
            //{
            //    Console.WriteLine($"{Car1.Id}\t{Car1.Plate}" +
            //        $"\t{Car1.Make}");
            //}
            //Console.WriteLine("----------------------------------------------");

            // Parkera bil
            //rowsAffected = DatabaseDapper.ParkCar(6, 12);
            //Console.WriteLine("Antal bilar parkerade: " + rowsAffected);
        }
    }
}

//Din uppgift är att bygga vidare på detta, I en console-app
//◦ 1.Kunna se lista på städer, och lägga till städer= KLART
//◦ 2.Kunna se lista på parkeringshus och lägga till parkeringshus och parkeringsplatser (samt ange om
//platsen har eluttag)=KLAR
//◦3. Kunna växla mellan olika städer och parkeringshus för att se vilka platser som är lediga =KLAR

//◦4. Kunna välja en bil och ett parkeringshus + plats för att parkera bilen=KLAR
//◦ 5.Kunna välja en bil för att “köra iväg” bilen
//◦ 6.Kunna lägga till ny bil, via inmatning=KLAR

//◦ Kunna se följande vyer, I console-appen:
//◦ Antal Elplatser per parkeringshus
//◦ Antal Elplatser per stad
//◦ Se Parkerade bilar
//◦ Lediga platser