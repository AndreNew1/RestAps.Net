using Calculadora.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Calculadora.Data.VO;

namespace Calculadora.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _LoginService;
        public LoginController(ILoginBusiness loginService)
        {
            _LoginService = loginService;
        }
        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] UserVO user)
        {
            if (user == null) return NotFound();
            return _LoginService.FindByLogin(user);
        }
    }
}
