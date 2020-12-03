using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPIsCore.Models;
using WebAPIsCore.Data;

namespace WebAPIsCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private DBContext db;

        public LoginController(IConfiguration config)
        {
            _config = config;
            db = new DBContext(config);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            //var user = AuthenticateUser(login);
            User u = new User();
            u.firstName = login.Username;
            u.password = login.EmailAddress;
            var ucheck = AuthUser(u);
           
                if(ucheck != null)
                {
                    var tokenString = GenerateJSONWebToken();
                    response = Ok(new { token = tokenString });

                }
                
           

            return response;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

               
            if (login.Username == "Prabhu")
            {
                user = new UserModel { Username = "Prabhakaran", EmailAddress = "prabhakaran@satvatinfosol.com" };
            }
            return user;
        }

        private User AuthUser(User login)
        {
            User user = null;
            List<User> userList = db.getAllUsers();
            user = userList.SingleOrDefault(s => (s.firstName == login.firstName && s.password == login.password));            
            return user;
        }
    }
}
