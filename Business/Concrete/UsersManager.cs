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
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        [ValidationAspect(typeof(UsersValidator))]
        public IResult Add(Users entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
