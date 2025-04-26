using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //Mapping from the Dto to the Entity to be added in database
            var studentMapper = _mapper.Map<Student>(request);

            //Add the entity to database
            var result = await _studentService.AddAsync(studentMapper);

            //Check the condition
            if (result == "Existing") return UnprocessableEntity<string>("Name is already existing");

            else if (result == "Success")
                return Created("Added Successfully");
            else
                return BadRequest<string>();
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if the student is existing
            var student = await _studentService.GetStudentAsync(request.Id);

            if (student == null)
                return NotFound<string>();

            var studMapper = _mapper.Map<Student>(request);

            var result = await _studentService.EditAsync(studMapper);
            if (result == "Success")
                return Created("Edit Successfully");
            else
                return BadRequest<string>();
        }

    }
}
