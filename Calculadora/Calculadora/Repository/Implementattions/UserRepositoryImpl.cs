using System.Linq;
using Calculadora.Model;
using Calculadora.Model.Context;

namespace Calculadora.Repository.Implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {

        private readonly MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }
        //Metodo responsavel por criar uma nova pessoa
        
        
        //Login
        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.Login.Equals(login));
        }

        
    }
}
