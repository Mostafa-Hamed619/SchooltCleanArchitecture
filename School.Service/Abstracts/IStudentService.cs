using School.Data.Entities;

namespace School.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentAsync(int id);
        public Task<string> AddAsync(Student student);

        public Task<string> EditAsync(Student model);

        public IQueryable<Student> GetStudentQueryable();

        public IQueryable<Student> FilterStudentPaginatedQuerabla(string search);
    }
}
