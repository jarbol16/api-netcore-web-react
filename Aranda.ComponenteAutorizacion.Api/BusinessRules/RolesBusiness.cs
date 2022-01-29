using Aranda.ComponenteAutorizacion.Entities;
using BusinessRules.Interfaces;
using DataAccess;
using System.Collections.Generic;

namespace BusinessRules
{
    public class RolesBusiness : IRolesBusiness
    {
        private readonly IRepository repository;
        public RolesBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public List<Rol> GetProfiles()
        {
            return this.repository.GetProfiles();
        }

        public List<Permiso> GetPermisions()
        {
            return this.repository.GetPermisions();
        }
    }
}
