using Calculadora.Model;
using Calculadora.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Repository.Generic
{
    public interface IPersonRepository :IRepository<Person>
    {
        List<Person> FindByName(string firstName,string lastName);
    }
}
