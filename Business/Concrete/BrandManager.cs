using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal ıbrandDal)
        {
            _brandDal = ıbrandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            if (entity.Name.Length<2)
            {
                return new ErrorResult(Message.CarNameInvalid);
            }
            _brandDal.Add(entity);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Delete(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==id));
        }

        public IResult Update(Brand entity)
        {
            if (entity.BrandId < 2) 
            {
                return new ErrorDataResult<Brand>(Message.CarNameInvalid);
            }
            _brandDal.Update(entity);
            return new ErrorDataResult<Brand>(Message.CarUptaded);
        }
    }
}
