﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismo.Template.Application.Services;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.API.Controllers
{
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoControllers : ControllerBase
    {
        private readonly IEmpleadoServices _service;

        public EmpleadoControllers(IEmpleadoServices service)
        {
            _service = service;
        }

        // GET: Empleados
        [HttpGet]
        [ProducesResponseType(typeof(List<UserByEmailDto>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] string email)
        {
            try
            {
                return new JsonResult(_service.GetEmpleadoByEmail(email)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // POST: Cargar Empleado
        [HttpPost]
        public IActionResult Post(EmpleadoDto empleado)
        {
            try
            {
                return new JsonResult(_service.Create(empleado)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return new JsonResult(_service.getId(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteId(int id)
        {
            try
            {
                var user = _service.getId(id);
                if (user != null)
                {
                    _service.deleteId(id);
                    return new JsonResult(user) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(user) { StatusCode = 404 };
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
