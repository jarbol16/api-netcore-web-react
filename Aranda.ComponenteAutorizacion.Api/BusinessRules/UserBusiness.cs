using Aranda.ComponenteAutorizacion.Entities;
using DataAccess;
using System.Collections.Generic;
using Utilities;

namespace BusinessRules
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository repository;
        public UserBusiness(IRepository repository)
        {
            this.repository = repository;
        }
        public Usuario ValidateLogin(UserCredentials credentials)
        {
            Usuario user = this.repository.GetUser(credentials.UserName, credentials.Password);
            if (user != null)
            {
                user.Persona = this.repository.GetPerson(user.Id);
                user.Permisos = this.repository.GetPermisionsByRol((int)user.RolId);
            }
            return user;
        }

        public List<Usuario> GetUsers(string userName)
        {
            return this.repository.GetList<Usuario>();
        }
    }
}
