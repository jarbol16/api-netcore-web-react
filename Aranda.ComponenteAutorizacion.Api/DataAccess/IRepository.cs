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
        List<string> GetPermisionsByRol(int rolId);

        List<Usuario> GetList();
        List<T> GetList<T>() where T : class, new();
    }
}
