using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
                return new ErrorResult(Messages.ProductNameInvalid);
            else if (car.DailyPrice <= 0)
                return new ErrorResult(Messages.ProductPriceInvalid);
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeletedSuccessfuly);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdatedSuccessfuly);
        }
    }
}
