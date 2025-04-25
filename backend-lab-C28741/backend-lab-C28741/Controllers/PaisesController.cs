﻿using backend_lab_C28741.Handlers;
using backend_lab_C28741.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_C28741.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
       private readonly PaisesHandler _paisesHandler;
        
        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }

        [HttpGet]
        public List<PaisModel> Get()
        {
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearPais(PaisModel pais)
        {
            try
            {
                if (pais == null)
                {
                    return BadRequest("El pais no puede ser nulo");
                }
                PaisesHandler paisesHandler = new PaisesHandler();
                var resultado = paisesHandler.CrearPais(pais);
                return new JsonResult(resultado);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el pais");
            }
        }
    }
}
