using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Registration.Api.Dto;
using Registration.Api.Entities;
using Registration.Api.Repositories.Abstractions;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Registration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegistrationRepository _repository;
        private readonly IMapper _mapper;

        public RegisterController(IRegistrationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAllUsersAsync();


            if (users.Count() > 0)
                return Ok(users);
            //var result = _mapper.Map<List<UserRegistrationDto>>(users);

            return Ok();
        }

        // GET: api/<RegisterController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _repository.GetByIdAsync(id);


            if (user != null)
            {
                var result = _mapper.Map<UserRegistrationDto>(user);
                return Ok(result);
            }
            return NotFound();
        }



        // POST api/<RegisterController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegistrationDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var user = _mapper.Map<UserRegistrationForm>(model);
            var result = await _repository.CreateAsync(user);
            if (!result)
                return BadRequest();


            return Ok();
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserRegistrationDto model)
        {
            var user = _mapper.Map<UserRegistrationForm>(model);
            var result = await _repository.UpdateAsync(id, user);
            if (result)
                return Ok();


            return BadRequest();
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            var result = await _repository.DeleteAsync(user);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
