using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        [ValidationAspect(typeof(RentalsValidator))]
        public IResult Add(Rentals entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rentals> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rentals entity)
        {
            throw new NotImplementedException();
        }
    }
}
