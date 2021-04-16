using BusinessLayer.Abstract;
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
        IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult DeleteRent(Rental rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult DeliverCar(Rental rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IResult Add(Rental rental)
        {
            var isRented = rentalDal.GetAll(p=>p.CarId == rental.CarId).Any(p=>p.ReturnDate == null);
            if(isRented)
            {
                return new ErrorResult("Araba teslim edilmemişken kiralanamaz.");
            }
            else
            {
                rentalDal.Add(rental);
                return new SuccessResult();
            }
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
