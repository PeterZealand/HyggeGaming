using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IRoleService
    {
        public IEnumerable<Role> GetRoles();
    }
}
