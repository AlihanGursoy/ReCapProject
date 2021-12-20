using Core.Entities;
using Core.Utilities.Results;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(int id);
        IResult Update(T entity);
        IDataResult<T> GetById(int id);

    }
}
