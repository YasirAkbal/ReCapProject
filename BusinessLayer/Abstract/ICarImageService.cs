using Core.DTOs;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, FileDto fileDto);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage, FileDto fileDtoForNewImage);
        IDataResult<CarImage> GetByCarImageId(int carImageId);
        IDataResult<List<CarImage>> GetAllImagesByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
    }
}
