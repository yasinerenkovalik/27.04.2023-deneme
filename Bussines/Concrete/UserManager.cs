using Bussines.Abstract;
using Bussines.Constants;
using Core.Entities.Concreate;
using Core.Utilities.Resaults;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWD;
using DataAccess.Abstract;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public class AuthManager : IAuthService
        {
            private IUserService _userService;
            private ITokenHelper _tokenHelper;

            public AuthManager(IUserService userService, ITokenHelper tokenHelper)
            {
                _userService = userService;
                _tokenHelper = tokenHelper;
            }

            public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user,"kayıt oldu");
            }

            public IDataResult<User> Login(UserForLoginDto userForLoginDto)
            {
                var userToCheck = _userService.GetByMail(userForLoginDto.Email);
                if (userToCheck == null)
                {
                    return new ErrorDataResult<User>("kullanıcı bulunamadı");
                }

                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    return new ErrorDataResult<User>("şifre yanlıs");
                }

                return new SuccessDataResult<User>(userToCheck, "basarili giris");
            }

            public IResult UserExists(string email)
            {
                if (_userService.GetByMail(email) != null)
                {
                    return new ErrorResult("kullanıcı mevcut" );
                }
                return new SuccessResult();
            }

            public IDataResult<AccessToken> CreateAccessToken(User user)
            {
                var claims = _userService.GetClaims(user);
                var accessToken = _tokenHelper.CreateToken(user, claims);
                return new SuccessDataResult<AccessToken>(accessToken, "bu boştu");
            }

            IDataResult<Azure.Core.AccessToken> IAuthService.CreateAccessToken(User user)
            {
                throw new NotImplementedException();
            }
        }
    }
}
