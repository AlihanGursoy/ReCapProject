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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _colorDal = ıColorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        {
            if (entity.Id < 0) 
            {
                return new ErrorResult(Message.CarNameInvalid);
            }
            _colorDal.Add(entity);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Delete(int id)
        {

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
            
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Update(Color entity)
        {
            if (entity.Id <= 0)
            {
                return new ErrorResult(Message.CarNameInvalid);
            }

            _colorDal.Update(entity);
            return new SuccessResult(Message.CarUptaded);
        }
    }
}
