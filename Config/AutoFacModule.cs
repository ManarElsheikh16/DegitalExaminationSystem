using DigitalExaminationSys.Models;
using DigitalExaminationSys.Repository.Interfaces;
using DigitalExaminationSys.Repository;
using DigitalExaminationSys.UnitOfWork;
using Autofac;
using DigitalExaminationSys.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace DigitalExaminationSys.Config
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Context)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(unitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly).InstancePerLifetimeScope();


        }
    }
}
