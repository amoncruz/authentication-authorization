using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InfoSolutionTeste.Services;
using InfoSolutionTeste.DTO;
using InfoSolutionTeste.Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    [Route("v1/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = await _unitOfWork.UserRepository.List().FirstOrDefaultAsync(w => w.Username == model.Username && w.Password == w.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = new UserReadDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role
                },
                token = token
            };
        }
    }
}