using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;

namespace School.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.DId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
