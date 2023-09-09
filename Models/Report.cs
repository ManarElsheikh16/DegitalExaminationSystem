using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public class Report : IBaseModel<int>
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int TotalScore { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
