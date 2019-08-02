using System.Collections.Generic;
using System.Linq;
using Calculadora.Model;
using Calculadora.Model.Context;
using Calculadora.Repository.Generic;

namespace Calculadora.Repository.Implementattions
{
    public class PersonRepositoryImpl :GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoryImpl(MySQLContext context):base(context){}

        //chamada das listas
        public List<Person> FindByName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if(string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
            {
                return _context.Persons.ToList();
            }
        }
    }
}
