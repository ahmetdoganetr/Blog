using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blog.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blog.Core.Abstract;
using Blog.Infrastructure.Helpers;
using Blog.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Blog.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IConfiguration configuration;
        private IUser userRepository;

        public AccountController(IConfiguration configuration, IUser userRepository)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Token([FromBody] LoginApiModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userRepository.Find(model.UserName);

                    if (user == null)
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized);
                    }

                    if (!PasswordHash.Verify(model.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized);
                    }

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var key = Encoding.ASCII.GetBytes(configuration["AppSetting:SecurityKey"]);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Name.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                    return Ok(new { Token = token });
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterApiModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userRepository.Find(model.UserName);

                    if (user != null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı adı sistemde mevcut durumdadır, lütfen başka bir kullanıcı adı seçiniz." });
                    }

                    byte[] passwordHash, passwordSalt;

                    PasswordHash.Create(model.Password, out passwordHash, out passwordSalt);

                    var entity = new User()
                    {
                        Name = model.UserName,
                        Surname = model.Surname,
                        UserName = model.UserName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    };

                    bool result = userRepository.Insert(entity);

                    if (result)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
