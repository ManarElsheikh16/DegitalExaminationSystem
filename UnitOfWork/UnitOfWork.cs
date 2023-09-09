using DigitalExaminationSys.Models;
using DigitalExaminationSys.Repository.Interfaces;
using DigitalExaminationSys.Repository;
using Microsoft.AspNetCore.Identity;

namespace DigitalExaminationSys.UnitOfWork
{
    public class UnitOfWork
    {
        Context _context;
        UserManager<ApplicationUser> _userManager;

        public UnitOfWork(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            BeginTransaction();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }

        public void CommitChanges()
        {
            try
            {
                _context.SaveChanges();
                _context.Database.CurrentTransaction.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }

        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction is null)
            {
                _context.Database.BeginTransaction();
            }
        }



        public IGenericRepository<Student, string> StudentRepository => new GenericRepository<Student, string>(_context);
        public IGenericRepository<Professor, string> ProfessorRepository => new GenericRepository<Professor, string>(_context);
        public IGenericRepository<Course, int> CourseRepository => new GenericRepository<Course, int>(_context);
        public IGenericRepository<Exam, int> ExamRepository => new GenericRepository<Exam, int>(_context);
        public IGenericRepository<Question, int> QuestionRepository => new GenericRepository<Question, int>(_context);
        public IGenericRepository<Answer, int> AnswerRepository => new GenericRepository<Answer, int>(_context);
        public IGenericRepository<Option, int> OptionRepository => new GenericRepository<Option, int>(_context);
        public IGenericRepository<Report, int> ReportRepository => new GenericRepository<Report, int>(_context);
        public IGenericRepository<Response, int> ResponseRepository => new GenericRepository<Response, int>(_context);


    }
}
