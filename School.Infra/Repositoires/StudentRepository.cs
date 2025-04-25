using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infra.Abstracts;
using School.Infra.Context;
using School.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Repositoires
{
    public class StudentRepository : GenericRepositoryAsync<Student>,IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(s => s.Departments).ToListAsync();
        }
    }
}
