using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public class Course : IBaseModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Exam> Exams { get; set; }
        [ForeignKey("Professor")]
        public string ProfessorId { get; set; }
        public Professor Professor { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
