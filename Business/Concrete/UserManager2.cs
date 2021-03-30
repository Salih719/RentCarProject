using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager2 : IUserService2
    {
        IUserDal2 _userDal2;

        public UserManager2(IUserDal2 userDal2)
        {
            _userDal2 = userDal2;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User2 user2)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal2.GetClaims(user2));
        }

        public IResult Add(User2 user2)
        {
            _userDal2.Add(user2);
            return new SuccessResult(Messages.User2Added);
        }

        public IDataResult<User2> GetByMail(string email)
        {
            return new SuccessDataResult<User2>(_userDal2.Get(u => u.Email == email));
        }
    }
}
