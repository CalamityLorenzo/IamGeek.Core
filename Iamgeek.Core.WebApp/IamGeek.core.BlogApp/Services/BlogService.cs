using IamGeek.core.Db;
using IamGeek.core.Db.Manager;
using IamGeek.core.Db.UnitOfWork;
using IamGeek.core.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BlogService
    {
        public static void AddBlog(this IServiceCollection @this)
        {
            @this.AddTransient<ISqlBlogUnitOfWork>((isrv) => UnitOfWorkFactory.Instance.Get<ISqlBlogUnitOfWork>("Data Source=.\\SQLEXPRESS;Initial Catalog=pclBlogDb;integrated security=true"));
            @this.AddTransient<ISqlBlogManager, SqlBlogManager>();
        }
    }
}
