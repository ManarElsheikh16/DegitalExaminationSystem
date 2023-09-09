using DigitalExaminationSys.Models;
using DigitalExaminationSys.Repository.Interfaces;
using DigitalExaminationSys.Repository;
using DigitalExaminationSys.UnitOfWork;
using Autofac;
using DigitalExaminationSys.Services;

namespace DigitalExaminationSys.Config
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Context)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();
          //  builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly).InstancePerLifetimeScope();

        }
    }
}
