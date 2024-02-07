using BackPrueba.DTO;
using BackPrueba.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackPrueba.Controllers
{
    [Route("api/v1/persona")]
    [ApiController]
    [Authorize]
    public class PersonaController : Controller
    {

        public readonly ApidbContext _dbcontext;

        public PersonaController(ApidbContext _context)
        {
            _dbcontext = _context;
        }
        [HttpGet]       
        public IActionResult Lista()
        {
            List<Persona> lista = new List<Persona>();

            try { 
            
                lista = _dbcontext.Personas.Where(p =>p.Eliminado == 0).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("{idProducto}")]
        public IActionResult Obtener(string idProducto)
        {
            Persona oProducto = _dbcontext.Personas.Find( new Guid(idProducto) );

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                oProducto = _dbcontext.Personas.Where(p => p.Id ==  new Guid(idProducto)).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProducto });


            }
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] PersonaDTO personaDTO)
        {
            try
            {

                Persona nuevaPersona = new Persona() {
                    Id = Guid.NewGuid(),
                    Eliminado = 0,
                    ApellidoMaterno = personaDTO.ApellidoMaterno,
                    ApellidoPaterno = personaDTO.ApellidoPaterno,
                    CorreoElectronico = personaDTO.CorreoElectronico,
                    Direccion = personaDTO.Direccion,
                    Nombres = personaDTO.Nombres,
                    NumeroDocumento = personaDTO.NumeroDocumento,
                    NumeroTelefono = personaDTO.NumeroTelefono  ,
                    TipoDocumento = personaDTO.TipoDocumento,
                };
                _dbcontext.Personas.Add(nuevaPersona);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }


        [HttpPut]
        [Route("{idProducto}")]
        public IActionResult Editar(string idProducto , [FromBody] PersonaDTO personaDTO)
        {
            Persona oProducto = _dbcontext.Personas.Find( new Guid(idProducto));

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {
                oProducto.ApellidoMaterno = personaDTO.ApellidoMaterno is null ? oProducto.ApellidoMaterno : personaDTO.ApellidoMaterno;
                oProducto.ApellidoPaterno = personaDTO.ApellidoPaterno is null ? oProducto.ApellidoPaterno : personaDTO.ApellidoPaterno;
                oProducto.NumeroDocumento = personaDTO.NumeroDocumento is null ? oProducto.NumeroDocumento : personaDTO.NumeroDocumento;
                oProducto.TipoDocumento = personaDTO.TipoDocumento is null ? oProducto.TipoDocumento : personaDTO.TipoDocumento;
                oProducto.CorreoElectronico = personaDTO.CorreoElectronico is null ? oProducto.CorreoElectronico : personaDTO.CorreoElectronico;
                oProducto.Direccion = personaDTO.Direccion is null ? oProducto.Direccion : personaDTO.Direccion;
                oProducto.Nombres = personaDTO.Nombres is null ? oProducto.Nombres : personaDTO.Nombres;



                _dbcontext.Personas.Update(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }

        [HttpDelete]
        [Route("{idProducto}")]
        public IActionResult Eliminar(string idProducto)
        {

            Persona oProducto = _dbcontext.Personas.Find(new Guid(idProducto));

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {
                oProducto.Eliminado = 1;

                _dbcontext.Personas.Update(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

    }
}
