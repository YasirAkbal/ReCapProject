using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id=1,BrandId=1,ColorId=2,DailyPrice=300,ModelYear=2012,Description="Bmw x 31"},
                new Car(){Id=2,BrandId=1,ColorId=4,DailyPrice=500,ModelYear=2014,Description="Toyota Pikap"},
                new Car(){Id=3,BrandId=2,ColorId=1,DailyPrice=700,ModelYear=2011,Description="Mercedes C 45"},
                new Car(){Id=4,BrandId=3,ColorId=3,DailyPrice=350,ModelYear=2008,Description="Audi A 5"},
                new Car(){Id=5,BrandId=4,ColorId=2,DailyPrice=200,ModelYear=2005,Description="Tofaş"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
