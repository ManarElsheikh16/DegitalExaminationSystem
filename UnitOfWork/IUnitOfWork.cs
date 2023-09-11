using DigitalExaminationSys.Models;
using DigitalExaminationSys.Repository.Interfaces;

namespace DigitalExaminationSys.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void CommitChanges();
        void BeginTransaction();
        IGenericRepository<Answer, int> AnswerRepository { get; }
        IGenericRepository<Course, int> CourseRepository { get; }
        IGenericRepository<Exam, int> ExamRepository { get; }
        IGenericRepository<Option, int> OptionRepository { get; }
        IGenericRepository<Professor, string> ProfessorRepository { get; }
        IGenericRepository<Student, string> StudentRepository { get; }
        IGenericRepository<Question, int> QuestionRepository { get; }
        IGenericRepository<Report, int> ReportRepository { get; }
        IGenericRepository<Response, int> ResponseRepository { get; }

    }
}
