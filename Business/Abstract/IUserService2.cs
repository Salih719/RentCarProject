using Core.Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService2
    {
        IDataResult<List<OperationClaim>> GetClaims(User2 user2);
        IResult Add(User2 user2);
        IDataResult<User2> GetByMail(string email);
    }
}
