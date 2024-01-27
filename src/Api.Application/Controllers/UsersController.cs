using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<string>> Put(int id)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     return Ok("UserController - Put");
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<string>> Delete(int id)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     return Ok("UserController - Delete");
        // }
    }
}
