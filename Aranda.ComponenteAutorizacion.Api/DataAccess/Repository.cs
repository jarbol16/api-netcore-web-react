using Aranda.ComponenteAutorizacion.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private readonly MainContext context;

        public Repository(MainContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtencion de Listas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetList()
        {
            return this.context.Usuarios.ToList();
        }

        //TODO: Esto o es seguro, debe ser valores encriptados
        /// <summary>
        /// Obtencion de usuario logueado
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Usuario GetUser(string userName, string pass)
        {
            //context.Personas.Add(new Persona { Apellido = "Arbol", Direccion = "car", Edad = 18, Email = "j.com", Nombre = "Pedro", Telefono = "2570661" });
            //context.SaveChanges();
            Usuario user = context.Usuarios.FirstOrDefault(user => user.Nombre.Equals(userName) && user.Contrasena.Equals(pass) && user.Persona.Id > 0);
            if(user != null)
            {
                user.Persona = GetPerson(user.PersonaId.Value);
                user.Rol = GetRol(user.RolId.Value);
            }
            return user;
        }

        /// <summary>
        /// Retorna la persona correspondiente a 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Persona GetPerson(int id)
        {
            return context.Personas.FirstOrDefault(person => person.Id == id);
        }

        public Rol GetRol(int id)
        {
            return context.Rols.FirstOrDefault(rol => rol.Id == id);
        }

        public List<PermisosPorRol> GetPermissionsByUser(int id)
        {
            Usuario user = context.Usuarios.FirstOrDefault(user => user.Id == id);
            return context.PermisosPorRols.Where(x => x.Rol.Id == user.Rol.Id).ToList();
        }

        public List<Usuario> GetUsers()
        {
            return context.Usuarios.ToList();
        }

        public List<Persona> GetPersons()
        {
            return context.Personas.ToList();
        }

        public List<Rol> GetProfiles()
        {
            return context.Rols.ToList();
        }

        public List<Permiso> GetPermisions()
        {
            return context.Permisos.ToList();
        }

        public List<string> GetPermisionsByRol(int rolId)
        {
            return (from per in context.PermisosPorRols
                        join permiso in context.Permisos on per.PermisoId equals permiso.Id
                        select permiso.Nombre ).ToList();

        }
    }
}
