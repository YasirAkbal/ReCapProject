using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult DeleteRent(Rental rental);
        IResult DeliverCar(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
    }
}
