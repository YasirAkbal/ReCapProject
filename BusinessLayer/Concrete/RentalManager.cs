using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this._rentalDal = rentalDal;
        }

        public IResult DeleteRent(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult DeliverCar(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRule.Run(CheckCarIsRented(rental.CarId));
            
            if(result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckCarIsRented(int carId)
        {
            var isRented = _rentalDal.GetAll(p => p.CarId == carId).Any(p => p.ReturnDate == null);
            if(isRented)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarIsNotReturned);
        }
    }
}
