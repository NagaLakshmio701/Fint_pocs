using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EmployeeAPI.Repositories.RolesRepositories;
using System.Data;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRolesRepository _rolesRepository;
        public RolesController(IConfiguration configuration, IRolesRepository rolesRepository)
        {
            _configuration = configuration;
            _rolesRepository=rolesRepository;
        }

       
        // GET: api/roles
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRoles()
        {
            var roles = await _rolesRepository.GetAllRolesAsync();
            return Ok(roles); // Wrap the result in an ActionResult
        }

        // GET: api/roles/{id
    
    [HttpGet("GetByID/{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var role = await _rolesRepository.GetRoleByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    // POST: api/roles
    [HttpPost("AddRole")]
    public async Task<IActionResult> CreateRole([FromBody] Roles role)
    {
        await _rolesRepository.AddRoleAsync(role);
        return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role);
    }

    // PUT: api/roles/{id}
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateRole([FromBody] Roles role)
    {
       
        await _rolesRepository.UpdateRoleAsync(role);
        return NoContent();
    }

    // DELETE: api/roles/{id}
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        await _rolesRepository.DeleteRoleAsync(id);
        return NoContent();
    }
}
}

