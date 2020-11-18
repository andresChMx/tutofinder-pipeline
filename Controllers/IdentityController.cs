using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;
using TutoFinder.Entity.Identity;

namespace TutoFinder.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        //Gestiona todo lo relacionado al usuario
        private readonly UserManager<ApplicationUser> _userManager;
        //Password
        private readonly SignInManager<ApplicationUser> _signInManager;
        //Para leer los datos del appsettings.json
        private readonly IConfiguration _configuration;

        public IdentityController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Correo,
                UserName = model.Correo,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, RoleHelper.Admin);
            
            if (!result.Succeeded)
            {
                throw new Exception("No se pudo crear el usuario.");
            }
            return Ok();
        }

        //identity/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Correo);

            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (check.Succeeded)
            {
                //return token
                return Ok(
                    await GenerateToken(user));
            }
            else
            {
                return BadRequest("Acceso no válido a la aplicación");
            }
        }

        [Authorize]
        [HttpGet("refresh_token")]
        public async Task<IActionResult> Refresh()
        {
            var userId = User.Claims.Where(x =>
                x.Type.Equals(ClaimTypes.NameIdentifier)
            ).Single().Value;

            var user = await _userManager.FindByIdAsync(userId);

            return Ok(
                await GenerateToken(user
                ));
        }
        //Generamos un token asociado a la cuenta del usuario
        private async Task<string> GenerateToken(ApplicationUser user)
        {
            //Definimos un secretKey
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            //Los Claims contiene información relevante de nuestro usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Nombres),
                new Claim(ClaimTypes.Surname, user.Apellidos)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role));
            }

            //Contiene la información del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Los Claims contiene información relevante de nuestro usuario
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdtoken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdtoken);
        }
        
        
    }
}
