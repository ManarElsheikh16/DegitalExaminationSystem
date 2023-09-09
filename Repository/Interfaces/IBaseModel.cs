using System.ComponentModel;

namespace DigitalExaminationSys.Repository.Interfaces
{
    public interface IBaseModel<T>
    {
        public T Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
