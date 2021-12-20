using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarService _carService;
        public CarManager(ICarDal ıCarDal, ICarService carService)
        {
            _carDal = ıCarDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarLimitExceded());

            _carDal.Add(entity);
            return new SuccessResult(Message.CarAdded);

        }

        public IResult Delete(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            //job codes

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));


        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car entity)
        {
            if (entity.Id <= 0)
            {
                return new ErrorResult(Message.CarNameInvalid);
            }

            _carDal.Update(entity);
            return new SuccessResult(Message.CarUptaded);
        }
        private IResult CheckIfCarLimitExceded()
        {
            var result = _carService.GetAll();
            if (result.Data.Count>5)
            {
                return new ErrorResult(Message.CarLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
