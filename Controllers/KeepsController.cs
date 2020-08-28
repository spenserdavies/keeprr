using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;
        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }
        [HttpGet] //Get All api/keeps
        public ActionResult<IEnumerable<Keep>> Get() //TODO somehow gotta make this also get private ones if youre the poster
        {
            try
            {
                return Ok(_ks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("user")] // Get By User api/user
        [Authorize]
        public ActionResult<IEnumerable<Keep>> GetKeepsByUser()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ks.GetByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Keep> GetById(int id)
        {
            try
            {
                var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                string userId = "";
                if(claim != null){
                    userId = claim.Value;
                }
                return Ok(_ks.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Keep> Post([FromBody] Keep newKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newKeep.UserId = userId;
                Console.WriteLine(newKeep);
                return Ok(_ks.Create(newKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Keep> Edit(int id, [FromBody] Keep keepToUpdate)
        {
            try
            {
                keepToUpdate.Id = id;
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ks.Edit(keepToUpdate, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ks.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}