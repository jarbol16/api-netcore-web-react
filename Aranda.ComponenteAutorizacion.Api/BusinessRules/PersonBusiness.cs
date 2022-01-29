namespace BusinessRules
{
    using Aranda.ComponenteAutorizacion.Entities;
    using BusinessRules.Interfaces;
    using DataAccess;
    using System.Collections.Generic;
    public class PersonBusiness: IPersonBusiness
    {
        private readonly IRepository repository;
        public PersonBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public List<Persona> GetPersons(string userName)
        {
            return this.repository.GetPersons();
        }
    }
}
