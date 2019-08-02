using Calculadora.Model;

namespace Calculadora.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
