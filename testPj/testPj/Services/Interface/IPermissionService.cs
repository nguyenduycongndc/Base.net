using System.Collections.Generic;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermission();
        Task<IEnumerable<Permission>> GetPermissionByRoleName(string role);
        Task<Permission> GetPermissionByName(string actionName);
    }
}
