using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using App.BLL.Interfaces;
using App.BLL.Services;
using Ninject.Web.Common;


namespace App.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IGuestBookService>().To<GuestBookService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<IMessageService>().To<MessageService>();
        }
    }
}