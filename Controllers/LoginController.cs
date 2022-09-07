using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SNMedicTreatment.Helper;
using SNMedicTreatment.Models.Account;
using SNMedicTreatment.Models.Error;
using SNMedicTreatment.Models.Users;
using SNMedicTreatment.Services;
using System.Net;
using System.Threading.Tasks;


namespace SNMedicTreatment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly LoginService _service;

        public AccountController(LoginService service)
        {
            _service = service;
        }

        /* Lista todos os usuarios do banco
        public async Task<ActionResult<List<UserDTO>>> Login()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users.Select(u => new UserDTO(u)));
        }*/

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request">Objeto de request</param>
        /// <returns>Token</returns>
        [HttpPost] // Método
        [AllowAnonymous] // Sem autorização
        public async Task<ActionResult<string>> Login([FromBody] UserRequest request)
        {
            var user = _service.Find(request.Email);

            if (user == null) return BadRequest(new Error(HttpStatusCode.BadRequest, "Usuário não encontrado!"));
            if (user.Email == null) return BadRequest(new Error(HttpStatusCode.BadRequest, "Email é obrigatório!"));
            if (user.Password != request.Password) return BadRequest(new Error(HttpStatusCode.BadRequest, "Senha inválida!"));

            var userResponse = _service.Login(user);
            return Ok(userResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Create([FromBody] UserRequest request)
        {
            var user = _service.Find(request.Email);
            if (user != null) return BadRequest(new Error(HttpStatusCode.BadRequest, "Email já cadastrado!"));

            var _newUser = new User()
            {
                Email = request.Email,
                Password = request.Password,
            };
            _service.Create(_newUser);

            return Ok(_newUser);
        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody] User request)
        {
            var user = _service.Find(request.Email);
            if (user != null) return BadRequest(new Error(HttpStatusCode.BadRequest, "Email já cadastrado!"));

            _service.Create(request);

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete()
        {
            _service.Delete(IdentityHelper.GetId(User));
            return Ok();
        }


    }
}
