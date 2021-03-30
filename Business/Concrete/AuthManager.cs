using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService2 _userService2;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService2 userService2, ITokenHelper tokenHelper)
        {
            _userService2 = userService2;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User2> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user2 = new User2
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService2.Add(user2);
            return new SuccessDataResult<User2>(user2, Messages.UserRegistered2);
        }

        public IDataResult<User2> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService2.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User2>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User2>(Messages.PasswordError);
            }

            return new SuccessDataResult<User2>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService2.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User2 user2)
        {
            var claims = _userService2.GetClaims(user2).Data;
            var accessToken = _tokenHelper.CreateToken(user2, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
