using Aranda.ComponenteAutorizacion.Entities;
using System.Collections.Generic;

namespace BusinessRules.Interfaces
{
    public interface IPersonBusiness
    {
        List<Persona> GetPersons(string userName);
    }
}
