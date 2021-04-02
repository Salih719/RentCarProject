using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal2 : IEntityRepository<User2>
    {
        List<OperationClaim> GetClaims(User2 user2);
    }
}
