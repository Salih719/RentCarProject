using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User2> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User2> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User2 user2);
    }
}
