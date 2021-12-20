using Core.DataAccess;
using Core.Entities.Concrete;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUsersDal:IEntityRepository<Users>
    {
        List<OperationClaim> GetClaims(Users users);
    }
}
