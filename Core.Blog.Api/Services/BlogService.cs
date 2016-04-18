using IamGeek.core.Db;
using IamGeek.core.Db.Manager;
using IamGeek.core.Domain.Configuration;
using IamGeek.core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BlogService
    {
       public static void AddBlog(this IServiceCollection srv)
        {
            BlogConfigurationBuilder.AddConnection("Read", "Data Source=.\\SQLEXPRESS;Initial Catalog=pclBlogDb;integrated security=true");
            BlogConfigurationBuilder.AddConnection("ReadWrite", "Data Source=.\\SQLEXPRESS;Initial Catalog=pclBlogDb;integrated security=true");
            BlogConfigurationBuilder.AddBuilder("Common", (bConfig) => new SqlBlogManager(UnitOfWorkFactory.Instance.Get(bConfig.Connections["ReadWrite"])));
            BlogConfigurationBuilder.AddBuilder("NotSoCommon", (bConfig) => new SqlBlogManager(UnitOfWorkFactory.Instance.Get(bConfig.Connections["Read"])));
            BlogConfigurationBuilder.Build();

            srv.AddTransient(new ServiceDescriptor(typeof(ISqlBlogManager), BlogConfigurationBuilder.Config.Managers["ReadWrite"]));
        }
    }
}
