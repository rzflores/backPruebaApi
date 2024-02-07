using Microsoft.AspNetCore.Mvc;
using BackPrueba.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BackPrueba.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly string secretkey;
        public AuthController(IConfiguration config)
        {
            secretkey = config.GetSection("settings").GetSection("secretKey").ToString();
        }
        [HttpPost]
        [Route("generar")]
        public IActionResult Validar([FromBody] Usuario usuario)
        {

            if (usuario.correo.Equals("test@gmail.com") && usuario.clave.Equals("123"))
            {

                var KeyBytes = Encoding.UTF8.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.correo));

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)

                };


                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string token = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = token });
            }
            else {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = "", response = "" });
            }
        }
    }
}
