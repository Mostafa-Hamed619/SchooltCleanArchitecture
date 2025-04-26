using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Core.Wrapper;
using School.Data.Entities;
using School.Service.Abstracts;
using System.Linq.Expressions;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                                    IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
                                                    IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentAsync(request.Id);
            if (student == null)
                NotFound<GetSingleStudentResponse>();
            var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            // First we want to cast the GetStudentPaginatedListQuery from list to IQueryable to get GetStudentPaginatedListResponse
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(
                                                                                                e.StudentId, e.Name, e.Address, e.Departments.DName);

            // var querable = _studentService.GetStudentQueryable();
            var filterQuery = _studentService.FilterStudentPaginatedQuerabla(request.Search);
            var paginatedResult = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedResult;
        }

        //Expression<Func<Student, GetStudentPaginatedListResponse>> expression = CreateExpression();

        //private static Expression<Func<Student, GetStudentPaginatedListResponse>> CreateExpression()
        //{
        //    return e => new GetStudentPaginatedListResponse();
        //}
    }
}
