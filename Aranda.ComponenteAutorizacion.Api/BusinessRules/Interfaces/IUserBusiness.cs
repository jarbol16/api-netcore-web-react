using Aranda.ComponenteAutorizacion.Entities;
using System.Collections.Generic;
using Utilities;

namespace BusinessRules
{
    public interface IUserBusiness
    {
        Usuario ValidateLogin(UserCredentials credentials);
        List<Usuario> GetUsers(string userName);
    }
}
