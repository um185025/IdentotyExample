using IdentotyExample.Data;
using IdentotyExample.Models;
using IdentotyExample.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace IdentotyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterUser(InUserDto user)
        {
            var dbuser = new User
            {
                FirstName = user.Name,
                UserName = user.Email,
                Email = user.Email,
                LastName = user.LastName
            };
            var resultUser = await _userManager.CreateAsync(dbuser, user.Password);

            return Ok(resultUser);
        }

        public class LogInData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<ActionResult> LogIn(LogInData logInData)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(logInData.Username, logInData.Password, false, false);
            //if (signInResult.Succeeded)
            //{
            //    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:JwtPrivateKey"]));
            //    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            //    var accessTokenExpires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:AccessTokenDurationInMinutes"]));

            //    var loggedUser = await _userManager.FindByEmailAsync(logInData.Username);

            //    var claimsAccessToken = new List<Claim>
            //    {
            //        new Claim(JwtRegisteredClaimNames.Sub, loggedUser.Id),
            //        new Claim(JwtRegisteredClaimNames.UniqueName, loggedUser.UserName)
            //    };


            //    var accessToken = new JwtSecurityToken(
            //        signingCredentials: signingCredentials,
            //        claims: claimsAccessToken,
            //        audience: _configuration["JWT:Audience"],
            //        issuer: _configuration["JWT:Issuer"],
            //        expires: accessTokenExpires,
            //        notBefore: DateTime.UtcNow
            //    );


            //    return Ok(new AuthResultDTO
            //    {
            //        Token = new JwtSecurityTokenHandler().WriteToken(accessToken),
            //        TokenExpires = accessTokenExpires
            //    });
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok(signInResult);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult> GetUser(string id)
        {
            var user = await _context.Users.Include(user => user.Addresses).FirstOrDefaultAsync(user => user.Id == id);
            OutUserDto outUser = new OutUserDto
            {
                Addresses = null,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return Ok(outUser);
        }

        [HttpPost]
        [Route("AddAddress")]
        public async Task<ActionResult> AddAddress(InAddressOut inAddress)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == inAddress.UserId);
            if (user == null)
                return BadRequest();

            Address address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                City = inAddress.City,
                StreetName = inAddress.StreetName,
                StreetNumber = inAddress.StreetNumber,
                ZipCode = inAddress.ZipCode,
                User = user
            };

            _context.Add(address);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
