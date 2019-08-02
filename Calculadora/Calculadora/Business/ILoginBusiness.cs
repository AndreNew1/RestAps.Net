using System.Collections.Generic;
using Calculadora.Data.VO;
using Calculadora.Model;

namespace Calculadora.Business
{
    public interface ILoginBusiness
    {
       object FindByLogin (UserVO login);
    }
}
