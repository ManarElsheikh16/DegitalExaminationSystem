using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public class Answer:IBaseModel<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public bool IsCorrect { get; set; }

        public List<Response>? Responses { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
