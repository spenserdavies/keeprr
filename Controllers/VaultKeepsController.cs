using System;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<DTOVaultKeep> Post([FromBody] DTOVaultKeep newDTOVaultKeep)
        {
            try
            {
                var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if(claim != null){
                    newDTOVaultKeep.UserId = claim.Value;
                }
                return Ok(_vks.Create(newDTOVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }  

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<DTOVaultKeep> Delete(int id)
        {
            try
            {
                var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                string userId = "";
                if(claim != null){
                    userId = claim.Value;
                }
                return Ok(_vks.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}