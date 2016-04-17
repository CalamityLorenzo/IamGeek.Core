using GeekBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBlog.Domain.Factories
{
    public interface IUnitOfWorkFactory
    {
        IBlogUnitOfWork Readonly();
        IBlogUnitOfWork ReadWrite();
    //    TUnitOfWork GetUnitOfWork<TUnitOfWork>(string connectionName);
    }
}
