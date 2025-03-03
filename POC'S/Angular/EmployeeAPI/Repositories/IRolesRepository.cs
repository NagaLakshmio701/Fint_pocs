using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public interface IRolesRepository
    {

     
            Task<IEnumerable<Roles>> GetAllRolesAsync();
            Task<Roles> GetRoleByIdAsync(int id);
            Task AddRoleAsync(Roles role);
            Task UpdateRoleAsync(Roles role);
            Task DeleteRoleAsync(int id);
        }

    }

