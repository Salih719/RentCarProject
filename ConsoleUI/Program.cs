using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(new Rental { RentDate = DateTime.Now, ReturnDate = DateTime.Now, CarId = 1, CustomerId = 8 });
            //if (result.Success == true)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            RentalTest();


        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetCarRentalDetails();
            foreach (var rental in result.Data)
            {
                Console.WriteLine( " {0} :  {1} TL : {2} : {3}   ", rental.CarName, rental.DailyPrice, rental.CustomerName, rental.RentDate);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            Console.WriteLine("Araba ismi --- Rengi --- Günlük fiyat");
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                { 
                    Console.WriteLine(" {0} : {1} : {2} TL ", car.CarName, car.ColorName , car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
