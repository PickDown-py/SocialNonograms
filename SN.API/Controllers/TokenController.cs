using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SN.ApiServices.Abstract;
using SN.Model;

namespace SN.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticationUserModel user)
        {
            if (await _userService.IsUserValidAsync(user.Email, user.Password))
            {
                return new ObjectResult(await GenerateToken(user.Email));
            }

            return BadRequest();
        }

        private async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userService.GetByEmailAsync(username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, 
                    new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, 
                    new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
                
            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Nonograms are fun")), 
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims)
                );

            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };
            
            return output;
        }
    }
}