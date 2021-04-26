using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core;
using Core.Constants;
using Core.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        private const int _defaultCarImageId = 1;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, FileDto fileDto)
        {
            var result = BusinessRule.Run(CheckIfCarImageCountInRange(carImage.Id));

            if(result != null)
            {
                return result;
            }

            carImage.ImagePath = fileDto.FullPath;
            carImage.Date_ = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            var result = BusinessRule.Run(CheckIfCarHasNoImage(carId));

            if(result != null)
            {
                if (result.Message == Messages.CarHasNoImage)
                    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == _defaultCarImageId),
                        result.Message);
                else
                    return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==carImageId));
        }

        public IResult Update(CarImage carImage, FileDto fileDtoForNewImage)
        {
            carImage.ImagePath = fileDtoForNewImage.FullPath;
            carImage.Date_ = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageCountInRange(int carId)
        {
            var count = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(count >= 5)
            {
                return new ErrorResult(Messages.CarImageCountRangeIsExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarHasNoImage(int carId)
        {
            var ifAnyCarImageExists = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (ifAnyCarImageExists == false)
            {
                return new ErrorResult(Messages.CarHasNoImage);
            }
            return new SuccessResult();
        }

    }
}
