using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();

            builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
            builder.RegisterType<EfRentalsDal>().As<IRentalsDal>().SingleInstance();

            builder.RegisterType<CarImagesManager>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();
        }
    }
}
