using DigitalExaminationSys.Extenstions;
using DigitalExaminationSys.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalExaminationSys.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context() { }

        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Response> Response { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyGlobalFilter<IBaseModel<int>>(x => !x.IsDeleted);

            modelBuilder.ApplyGlobalFilter<IBaseModel<string>>(x => !x.IsDeleted);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-07S7M2O;Initial Catalog=ExaminationSystem;Integrated Security=True; trust server certificate = true");
            }
        }

    
    }
}
