using Autofac;
using Ludens.BusinessLogic.Abstract;
using Ludens.BusinessLogic.Services;
using Ludens.DataAccess.Abstract;
using Ludens.DataAccess.Concrete;
using Module = Autofac.Module;

namespace Ludens.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //BLL
            builder.RegisterType<LudensBLL>().As<ILudensBLL>().InstancePerLifetimeScope();

            //DAL
            builder.RegisterType<LudensDAL>().As<ILudensDAL>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
