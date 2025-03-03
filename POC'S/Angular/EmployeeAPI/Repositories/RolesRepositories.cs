using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using static EmployeeAPI.Repositories.RolesRepositories;

namespace EmployeeAPI.Repositories
{
    public class RolesRepositories
    {
        public class RoleRepository : IRolesRepository
        {
            private readonly EmployeeDbContext _context;

            public RoleRepository(EmployeeDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Roles>> GetAllRolesAsync()
            {
                return await _context.Roles.ToListAsync();
            }

            public async Task<Roles> GetRoleByIdAsync(int id)
            {
                return await _context.Roles.FindAsync(id);
            }

            public async Task AddRoleAsync(Roles role)
            {
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateRoleAsync(Roles role)
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteRoleAsync(int id)
            {
                var role = await _context.Roles.FindAsync(id);
                if (role != null)
                {
                    _context.Roles.Remove(role);
                    await _context.SaveChangesAsync();
                }
            }

          
           

           
        }

    }
}
