using DBContextTourist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetUpController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<SetUpController> _logger;

        public SetUpController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            ILogger<SetUpController> _logger) : base(unitOfWork)
        {
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._logger = _logger;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleManager.Roles.ToList());
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromForm]string roleName)
        {
            var roleExist=await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"the role {roleName} has been added successfully");
                    return Ok($"the role {roleName} has been added successfully");
                }
                else
                {
                    _logger.LogInformation($"the role {roleName} has not been added ");
                    return BadRequest($"the role {roleName} has not been added ");
                }
            }
            return BadRequest(new {error="Role already exist"});
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole([FromForm] string roleName,string email)
        {
            //check if the user exists 
            var  user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"the user with  {email} doesn't exists ");
                return BadRequest($"the user with  {email} doesn't exists ");
            }

            //check if the role exists
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                _logger.LogInformation($"the role {roleName} doesn't exists");
                return BadRequest($"the role {roleName} doesn't exists ");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            //check if the user was assigned successfully to the role
            if (result.Succeeded)
            {
                return Ok(new { result = "success , user has been added to the role" });
            }
            else
            {
                _logger.LogInformation($"the role was not added to the user");
                return BadRequest($"the role was not added to the user");
            }
        }

        [HttpPost("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles([FromForm] string email)
        {
            var user= await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                _logger.LogInformation($"the user with  {email} doesn't exists ");
                return BadRequest($"the user with  {email} doesn't exists ");
            }

            var roles=await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [HttpDelete("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole([FromForm] string email, string roleName)
        {

            //check if the user exists 
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"the user with  {email} doesn't exists ");
                return BadRequest($"the user with  {email} doesn't exists ");
            }

            //check if the role exists
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                _logger.LogInformation($"the role {roleName} doesn't exists ");
                return BadRequest($"the role {roleName} doesn't exists ");
            }

            //check if the user was deleted successfully from the role

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new { result = "success , user has been removed from the role" });
            }
            else
            {
                return BadRequest($"unable to remove user {email} from role {roleName} ");
            }

        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromForm] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"the user with {email} doesn't exist");
                return BadRequest($"the user with {email} doesn't exist");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { result = "success, user has been deleted" });
            }
            else
            {
                _logger.LogInformation($"unable to delete user {email}");
                return BadRequest($"unable to delete user {email}");
            }
        }

    }
}
