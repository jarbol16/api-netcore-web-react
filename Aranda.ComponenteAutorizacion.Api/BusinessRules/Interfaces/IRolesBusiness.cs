using Aranda.ComponenteAutorizacion.Entities;
using System.Collections.Generic;

namespace BusinessRules.Interfaces
{
    public interface IRolesBusiness
    {
        List<Permiso> GetPermisions();
        List<Rol> GetProfiles();

    }
}
