using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.Helpers.Models;
using Los_Pollos_Hermanos.Models;
using Los_Pollos_Hermanos.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Los_Pollos_Hermanos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;


        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public int Amount { get; private set; }

        [HttpPost]
        public async  Task<IActionResult> CreateMenu(MenuApiModel model)
        {
            model.Id = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.Amount = Amount;
            return Ok(await _menuService.CreateAsync(model));
        }
    }
}
