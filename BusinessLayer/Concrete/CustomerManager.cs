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
    class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll());
        }

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
