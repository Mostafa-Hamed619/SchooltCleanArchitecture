using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;

namespace School.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {

        [HttpGet("students")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet("PaginationStudent")]
        public async Task<IActionResult> GetPaginatedStudent([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
