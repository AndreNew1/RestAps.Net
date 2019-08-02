using System.Collections.Generic;
using Calculadora.Data.Converters;
using Calculadora.Data.VO;
using Calculadora.Model;
using Calculadora.Repository;
using Calculadora.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace Calculadora.Business.Implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _repository;
        private readonly PersonConverter _Converter;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository= repository;
            _Converter = new PersonConverter();
        }
        //Metodo responsavel por criar uma nova pessoa
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _Converter.Parse(person);
            personEntity= _repository.Create(personEntity);
            return _Converter.Parse(personEntity);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        }
        public List<PersonVO> FindAll()
        {
            return _Converter.ParseList(_repository.FindAll());
        }
        public PersonVO FindById(long id)
        {
            return _Converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _Converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _Converter.Parse(personEntity);
        }
        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name,string sortDirection,int pageSize,int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from persons p where 1=1 ";
            if (!string.IsNullOrEmpty(name)) query += $"and p.Firstname like %{name}% ";
            query +=$" order by p.Firstname{sortDirection} limit {pageSize} offset{page}";

            string CountQuery= @"select count(*) from persons p where 1=1 ";
            if (!string.IsNullOrEmpty(name)) CountQuery += $"and p.Firstname like %{name}% ";


            var persons = _Converter.ParseList(_repository.FindWithPagedSearch(query));
            int totalResults = _repository.GetCount(CountQuery);
            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page+1,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _Converter.ParseList(_repository.FindByName(firstName, lastName));
        }
    }
}
