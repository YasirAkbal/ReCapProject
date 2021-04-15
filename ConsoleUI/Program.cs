using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var result = rentalService.Add(new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now });

            Console.WriteLine(result.IsSuccess);
            if (result.Message != null)
                Console.WriteLine(result.Message);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetAllCarDetails().Data)
            {
                Console.WriteLine($"Name = {c.CarName}, Color = {c.ColorName}, Brand = {c.BrandName}, DailyPrice = {c.DailyPrice}");
            }

            var result = carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 500, Description = "saaa", ModelYear = 2021 });

            Console.WriteLine(result.IsSuccess + " - " + result.Message);
        }
    }
}
