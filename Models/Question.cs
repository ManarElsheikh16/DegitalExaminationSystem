using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public enum Type
    {
        MultipleChioces,
        True_False,
        FillInBlank,
        EssayQuestion,
    }
    public class Question : IBaseModel<int>
    {

        public int Id { get; set; }
        public string Text { get; set; }

        public Type Type { get; set; }
        public List<Option> Options { get; set; }
        public int QuesGrade { get; set; }
        public string CorrectAnswe { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<Response> Responses { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
