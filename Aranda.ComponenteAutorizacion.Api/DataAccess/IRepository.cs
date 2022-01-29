using Aranda.ComponenteAutorizacion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRepository
    {
        Usuario GetUser(string userName, string pass);
        Persona GetPerson(int id);
        List<Permiso> GetPermisions();
        List<Rol> GetProfiles();
        List<Persona> GetPersons();
        List<Usuario> GetUsers();
        List<string> GetPermisionsByRol(int rolId);
    }
}
