using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        ICarImagesService _carImagesService;

        public CarImagesManager(ICarImagesDal carImagesDal, ICarImagesService carImagesService)
        {
            _carImagesDal = carImagesDal;
            _carImagesService = carImagesService;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(CarImages entity)
        {
            IResult result = BusinessRules.Run();
           
            _carImagesDal.Add(entity);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Delete(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImages entity)
        {
            if (entity.CarId < 2)
            {
                return new ErrorDataResult<CarImages>(Message.CarNameInvalid);
            }
            _carImagesDal.Update(entity);
            return new ErrorDataResult<CarImages>(Message.CarUptaded);
        }

        private IResult CheckIfImagePathLimitExceded()
        {
            var result = _carImagesService.GetAll();
            if (result.Data.Count>5)
            {
                return new ErrorResult(Message.CarImagesLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
