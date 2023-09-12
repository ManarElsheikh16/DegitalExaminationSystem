using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public class Exam : IBaseModel<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Professor")]
        public string ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public List<Question>? Questions { get; set; }
        public List<Response> ?Responses { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
