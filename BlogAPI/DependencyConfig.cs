using Autofac;
using BlogData;
using BlogData.Repositories;

namespace BlogAPI
{
    public class DependencyConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<BlogContext>().As<IBlogContext>();
            builder.Register(x =>
            {
                var context = x.Resolve<IBlogContext>();
                return new UnitOfWork(context);
            }).As<IUnitOfWork>();
        }
    }
}