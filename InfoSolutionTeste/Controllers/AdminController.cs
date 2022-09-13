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
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.UserRepository.List().Where(w=> w.Role == "Admin").ToListAsync());
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
