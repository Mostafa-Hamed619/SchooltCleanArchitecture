using AutoMapper;

namespace School.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentByIdMapping();
            GetStudentListMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
