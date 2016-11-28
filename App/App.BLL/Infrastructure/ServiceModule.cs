using System;
using Ninject.Modules;
using App.DAL.Interfaces;
using App.DAL.Repositories;

namespace App.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionName;
        public ServiceModule(string connection)
        {
            connectionName = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<AppUnitOfWork>().WithConstructorArgument(connectionName);
        }
    }
}
