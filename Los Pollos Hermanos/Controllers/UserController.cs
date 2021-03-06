using Amazon.DynamoDBv2.DataModel;
using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.ApiModels.RequestModels;
using Los_Pollos_Hermanos.Models;
using Los_Pollos_Hermanos.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Los_Pollos_Hermanos.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
     

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager, IUserService userService, IConfiguration configuration)
        {
            this._signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserApiModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var time = TimeZoneInfo.ConvertTimeToUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(_configuration.GetSection("AlbukerkeTimeZone").Value));
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed = true,
                    CreatedAt = time,
                    UpdatedAt = time,

                };
                var result = await _userManager.CreateAsync(user,model.Password );
                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByEmailAsync(user.Email);
                    await _userManager.AddToRolesAsync(newUser, new[] { "User" });
                    var data = await _userService.GetUserByUserEmail(model.Email);
                    return Ok(data);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserApiModel),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] LoginUser model)
        {
            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user, false);
                var data = await _userService.GetUserByUserEmail(model.Email);
                if (data != null)
                {
                    return Ok(data);
                }
            }
            return NotFound();
        }
        
    }
}
