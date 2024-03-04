using DevLarTech.Application.Commands.CreatePerson;
using DevLarTech.Application.Commands.CreateTelephone;
using DevLarTech.Application.Commands.DeletePerson;
using DevLarTech.Application.Commands.UpdatePerson;
using DevLarTech.Application.Commands.UpdateTelephone;
using DevLarTech.Application.Queries.GetAllPerson;
using DevLarTech.Application.Queries.GetPersonById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLarTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllPersonQuery = new GetAllPersonQuery(query);

            var person = await _mediator.Send(getAllPersonQuery);

            return Ok(person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query  = new GetPersonByIdQuery(id);

            var person = await _mediator.Send(query);

            if(person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            if(command.FullName.Length > 255)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("{id}/telephone")]
        public async Task<IActionResult> PostTelephone(int id, [FromBody] CreateTelephoneCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePersonCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/telephone")]
        public async Task<IActionResult> PutTelephone(int id, [FromBody] UpdateTelephoneCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePersonCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
