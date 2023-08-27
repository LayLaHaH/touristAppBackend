using DBContextTourist;
using DBContextTourist.Models;
using DBContextTourist.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace touristApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthenticationController> _logger;


        public AuthenticationController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> _userManager,
            IConfiguration _configuration,
            RoleManager<IdentityRole> _roleManager,
            ILogger<AuthenticationController> _logger
            ) : base(unitOfWork)
        {
            this._userManager = _userManager;
            this._configuration = _configuration;
            this._roleManager = _roleManager;
            this._logger = _logger;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserRegistration registrationRequest)
        {
            if (ModelState.IsValid)
            {
                //check if the email already exist
                var user_exist = await _userManager.FindByEmailAsync(registrationRequest.Email);
                if (user_exist != null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                {
                    "Email already exists"
                }
                    });
                }

                //create a user 
                var new_user = new IdentityUser()
                {
                    Email = registrationRequest.Email,
                    UserName = registrationRequest.Name
                };

                var is_created = await _userManager.CreateAsync(new_user, registrationRequest.Password);

                if (is_created.Succeeded)
                {
                    await _userManager.AddToRoleAsync(new_user, "Company");
                    _unitOfWork.SaveChanges();

                    //generate a token
                    var token = await GenerateJwtTokenAsync(new_user);
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }
                else
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = is_created.Errors.Select(e => e.Description).ToList()
                    });
                }
            }

            return BadRequest();
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLogin loginRequest)
        {
            if (ModelState.IsValid)
            {
                //check if the email already exist
                var user_exist = await _userManager.FindByEmailAsync(loginRequest.Email);
                if (user_exist == null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "there is no such user"
                        }
                    });
                }
                var is_correct = await _userManager.CheckPasswordAsync(user_exist, loginRequest.Password);
                if (!is_correct)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        }
                    });
                }
                var token = await GenerateJwtTokenAsync(user_exist);
                return Ok(new AuthResult()
                {
                    Result = true,
                    Token = token
                });

            }

            return BadRequest(error: new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                        {
                            "Invalid payload"
                        }
            });
        }

        
        private async Task<List<Claim>> GetAllValidClaims(IdentityUser user)
        {
            var _options = new IdentityOptions();
            
            var claims=new List<Claim>
            {
                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString()),
            };

            //getting the claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            //get the user role and add it to the claims

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach(var userRole in userRoles)
            {
                var role= await _roleManager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims= await _roleManager.GetClaimsAsync(role);
                    foreach(var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims; 

        }

        private async Task<string> GenerateJwtTokenAsync(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key=Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

            var claims= await GetAllValidClaims(user);

            //token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
               Subject=new ClaimsIdentity(claims),
               Expires=DateTime.Now.AddHours(1),
               SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
            
        }


        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister([FromForm] UserRegistration registrationRequest)
        {
            if (ModelState.IsValid)
            {
                //check if the email already exist
                var user_exist = await _userManager.FindByEmailAsync(registrationRequest.Email);
                if (user_exist != null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                {
                    "Email already exists"
                }
                    });
                }

                //create a user 
                var new_user = new IdentityUser()
                {
                    Email = registrationRequest.Email,
                    UserName = registrationRequest.Name
                };

                var is_created = await _userManager.CreateAsync(new_user, registrationRequest.Password);

                if (is_created.Succeeded)
                {
                    await _userManager.AddToRoleAsync(new_user, "Admin");
                    _unitOfWork.SaveChanges();

                    //generate a token
                    var token = await GenerateJwtTokenAsync(new_user);
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }
                else
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = is_created.Errors.Select(e => e.Description).ToList()
                    });
                }
            }

            return BadRequest();
        }


    }
}
