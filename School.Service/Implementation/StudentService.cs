using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infra.Abstracts;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<string> AddAsync(Student student)
        {
            // Check if the name is already existing or not
            var studentResult =await _studentRepo.GetTableNoTracking().Where(x => x.Name.Equals(student.Name)).FirstOrDefaultAsync();

            if (studentResult != null)
                return "Existing";

            // Add student
            await _studentRepo.AddAsync(student);
            return "Success";
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _studentRepo.GetTableNoTracking()
                            .Include(s => s.Departments)
                            .Where(s => s.StudentId.Equals(id))
                            .FirstOrDefaultAsync();

            return student;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepo.GetStudentListAsync();
        }
    }
}
