using AdoptiPet.DTO;
using AdoptiPet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration Config;

        public AccountController(UserManager<ApplicationUser> userManager, IMapper mapper, IConfiguration Config)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            Config = Config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            var ExistingUserName = userManager.FindByNameAsync(registerDTO.UserName);
            if(ExistingUserName != null)
                return BadRequest("Name is already taken. Please choose a different name.");

            if (ModelState.IsValid)
            {
                var user = mapper.Map<ApplicationUser>(registerDTO);
                var result = await userManager.CreateAsync(user, registerDTO.Password);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
                return Ok("User registered successfully.");
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(loginDTO.Email);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, loginDTO.Password);
                    if (found)
                    {
                        List<Claim> UserClaims = new List<Claim>();
                        
                        UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        UserClaims.Add(new Claim(ClaimTypes.Email, user.Email));
                        UserClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var UserRoles = await userManager.GetRolesAsync(user);
                        foreach (var roleName in UserRoles)
                            UserClaims.Add(new Claim(ClaimTypes.Role, roleName));

                        var SignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["JWT: SecritKey"]));
                        SigningCredentials signingCred = new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken myToken = new JwtSecurityToken
                            (
                                audience: Config["JWT: AudienceIP"],
                                issuer: Config["JWT:IssuerIP"],
                                expires: DateTime.Now.AddHours(1),
                                claims: UserClaims,
                                signingCredentials: signingCred
                            );

                        return Ok(new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(myToken),
                                Expiration = DateTime.Now.AddHours(1)
                            });
                    }

                }
                ModelState.AddModelError("Email", "Email or Password is INCORRECT");
            }
            return BadRequest(ModelState);
        }
    }
}
