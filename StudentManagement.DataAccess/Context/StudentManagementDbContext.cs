using System.Data.Entity;
using StudentManagement.Api.Entities;

namespace StudentManagement.DataAccess.Context
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext()
            : base("name=StudentDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            



        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
