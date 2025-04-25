using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent([FromRoute]int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
