using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calculadora.Model;
using Calculadora.Model.Context;
using Calculadora.Repository;

namespace Calculadora.Business.Implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository= repository;
        }
        //Metodo responsavel por criar uma nova pessoa
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
