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
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<string>> Get(int id, string name)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     try
        //     {
        //         return Ok("UserController - Get with id " + id + " and name " + name);
        //     }
        //     catch (ArgumentException e)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        //     }
        // }

        // [HttpPost]
        // public async Task<ActionResult<string>> Post()
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     try
        //     {
        //         return Ok("UserController - Post");
        //     }
        //     catch (ArgumentException e)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        //     }
        // }

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
