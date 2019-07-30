using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calculadora.Model;
using Calculadora.Model.Context;

namespace Calculadora.Repository.Implementattions
{
    public class PersonRepositoryImpl : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }
        //Metodo responsavel por criar uma nova pessoa
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            return person;
        }
        public void Delete(long id)
        {
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) _context.persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Person> FindAll()
        {
            return _context.persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.persons.SingleOrDefault(p => id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return null;
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return person;
        }

        public bool Exist(long? id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }

        public bool Exists(long? id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
