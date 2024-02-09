using AutoMapper;
using Inventario.Api.Responses;
using Inventario.Entities.Dtos.Login;
using Inventario.Entities.Dtos.Users;
using Inventario.Entities.Users;
using Inventario.Services.Contrats;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto login)
        {
            string returnUrl = string.IsNullOrEmpty(Request.Query["returnUrl"]) ? Url.Content("~/") : Request.Query["returnUrl"];

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var users = await _userService.GetUsersAsync();
                    var user = users.FirstOrDefault(x => x.Username == login.Username);

                    return Ok(new
                    {
                        hasError = false,
                        message = "Authorized",
                        model = user,
                        requestId = System.Diagnostics.Activity.Current?.Id
                    });
                }

                if (result.IsLockedOut)
                {
                    return Ok(new
                    {
                        hasError = true,
                        message = "User is locked",
                        model = new { title= "Locked", message= "This user is locked, too many attemps" },
                        requestId = System.Diagnostics.Activity.Current?.Id
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Ok(new
                    {
                        hasError = true,
                        message = "User unauthorized",
                        model = new { title = "Unauthorized", message = "Your user or/and password are wrong" },
                        requestId = System.Diagnostics.Activity.Current?.Id
                    });
                }

            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "Bad request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }


        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            string returnUrl = string.IsNullOrEmpty(Request.Query["returnUrl"]) ? Url.Content("~/") : Request.Query["returnUrl"];

            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                return Ok(new
                {
                    hasError = false,
                    message = "Signed Out",
                    model = new { title = "Signed Out", message = "This user is signed out correctly" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else
            {
                return BadRequest(new
                {
                    hasError = true,
                    message = "One field is required",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }
    }
}
