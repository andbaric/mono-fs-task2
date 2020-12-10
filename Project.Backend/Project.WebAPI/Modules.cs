using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Project.DAL;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using System;

namespace Project.WebAPI
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterType<VehicleMakeRespository>().As<IVehicleMakeRespository>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelRespository>().As<IVehicleModelRespository>().InstancePerLifetimeScope();

            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();
        }
    }
}
