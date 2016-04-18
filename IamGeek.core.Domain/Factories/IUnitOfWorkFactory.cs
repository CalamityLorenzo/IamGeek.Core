using IamGeek.core.Db.Interfacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IamGeek.core.Domain.Factories
{
    public interface IUnitOfWorkFactory
    {
        IBlogUnitOfWork Readonly();
        IBlogUnitOfWork ReadWrite();
        IBlogUnitOfWork Get(string connection);
    //    TUnitOfWork GetUnitOfWork<TUnitOfWork>(string connectionName);
    }
}
