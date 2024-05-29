using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Req;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace QLBH.BLL
{
    public class AuthService : IAuthService
    {
        private IUserAuthRep _userAuthRep;

        public AuthService(IUserAuthRep userRepository)
        {
            _userAuthRep = userRepository;
        }

        public async Task<ClaimsPrincipal> LoginAsync(string username, string password)
        {
            var user = await _userAuthRep.GetUserByUserNameAndPassword(username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IsAdmin == 1 ? "Admin" : "User")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return claimsPrincipal;
            }
            else
            {
                return null;
            }
        }

        public interface IAuthService
        {
            Task<ClaimsPrincipal> LoginAsync(string email, string password);
            Task<bool> RegisterAsync(RegisterReq registerReq);
        }

        public async Task<bool> RegisterAsync(RegisterReq registerReq)
        {
            var existingUser = await _userAuthRep.CheckExistUser(registerReq.Name, registerReq.Email, registerReq.PhoneNumber);
            var existingCustomer = await _userAuthRep.CheckExistCustomer(registerReq.PhoneNumber);
            if (existingUser != null || existingCustomer != null)
            {
                return false; // User already exists
            }

            var newUser = new User
            {
                Name = registerReq.Name,
                Email = registerReq.Email,
                Password = registerReq.Password,
                IsAdmin = 0
            };

            var userResult = await _userAuthRep.CreateUserAsync(newUser);

            if (userResult > 0)
            {
                var newCustomer = new Customer
                {
                    UserId = newUser.UserId,
                    Surname = registerReq.Surname,
                    FirstName= registerReq.FirstName,
                    Title= registerReq.Title,
                    EmailCus= registerReq.EmailCus,
                    PhoneNumber = registerReq.PhoneNumber,
                    BuildingNumber= registerReq.BuildingNumber,
                    City= registerReq.City,
                    Postcode= registerReq.Postcode,
                    Country = registerReq.Country,
                    Area= registerReq.Area,
                };

                var customerResult = await _userAuthRep.CreateCustomerAsync(newCustomer);
                return customerResult > 0;
            }
            else
            {
                return false;
            }
        }
    }
    public interface IAuthService
    {
        Task<ClaimsPrincipal> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(RegisterReq registerReq);
    }
}
