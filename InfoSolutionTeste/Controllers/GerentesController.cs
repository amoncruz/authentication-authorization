using Domain.Enum;
using Domain.Interfaces;
using InfoSolutionTeste.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoSolutionTeste.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class GerentesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GerentesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.UserRepository.List().Where(w=> w.Role == "Gerente").ToListAsync());
        }


        // POST api/<ValuesController>
        // GET: api/clientes
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            user.DefinirRole(Roles.Gerente);

            await _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();

            return Ok();
        }


        // PUT api/<ValuesController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            user.DefinirRole(Roles.Gerente);

            var userEntity = await _unitOfWork.UserRepository.Get(id);

            userEntity.Username = user.Username;
            userEntity.DataNascimento = user.DataNascimento;
            userEntity.Nome = user.Nome;

             _unitOfWork.UserRepository.Update(userEntity);
            _unitOfWork.Commit();

            return Ok();
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userEntity = await _unitOfWork.UserRepository.Get(id);

            _unitOfWork.UserRepository.Delete(userEntity);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
