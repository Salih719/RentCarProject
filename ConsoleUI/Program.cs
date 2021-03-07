using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get All
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            //GetCarsByBrandId
            Console.WriteLine("----------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + " : " + car.Description);
            }


            Console.WriteLine("----------Bütün Renkleri sırala----------");


            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " : " + color.ColorName);
            }

            Console.WriteLine("----------Markaların id leri----------");


            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " : " + brand.BrandName);
            }


        }
    }
}
