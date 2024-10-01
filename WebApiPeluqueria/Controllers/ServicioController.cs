using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPeluqueria.Data.Models;
using WebApiPeluqueria.Data.Repository;

namespace WebApiPeluqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepositorio _repositorio;

        public ServicioController(IServicioRepositorio servicioRepositorio)
        {
            _repositorio = servicioRepositorio;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repositorio.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("servicio/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repositorio.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno. Explotó todo!!!!!!!!!!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servicio servicio)
        {
            try
            {
                _repositorio.Save(servicio);
                return Ok("Se agregó con éxito.");
            }
            catch (Exception)
            {

                return StatusCode(500, "Hermano... :(");
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutById(int id, [FromBody] Servicio serv)
        {
            try
            {
                if (serv == null)
                {
                    return BadRequest("Datos incompletos");
                }
                var oServ = _repositorio.GetById(id);
                if (oServ == null)
                {
                    return BadRequest("No se encontró el servicio!");
                }

                oServ.Nombre = serv.Nombre;
                oServ.EnPromocion = serv.EnPromocion;
                oServ.Costo = serv.Costo;

                _repositorio.Save(oServ);
                return Ok("Servicio actualizado. Bien ahí chango!");
            }
            catch (Exception)
            {

                return StatusCode(500, "¿Cómo te lo digo sin que te enojes?");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var serv = _repositorio.GetById(id);
                if (serv == null)
                {
                    return BadRequest("Error. No se encontró el servicio!");
                }
                _repositorio.Remove(id);
                return Ok("Desaparecimos el servicio con éxito.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Se acabó lo que se daba maestro. Murió el server");
            }
        }
    }
}
