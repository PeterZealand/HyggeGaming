using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Services.EFService
{
    public class EFRoleService: IRoleService
    {
        private HGDBContext context;
        public EFRoleService(HGDBContext service)
        {
            context = service;
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles;
        }
    }
}
