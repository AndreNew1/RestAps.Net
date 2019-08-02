using System.Collections.Generic;
using Calculadora.Data.VO;
using Tapioca.HATEOAS.Utils;

namespace Calculadora.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName,string lastName);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
