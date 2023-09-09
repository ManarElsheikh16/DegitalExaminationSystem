using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;

namespace DigitalExaminationSys.Models
{
    public class Option : IBaseModel<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
