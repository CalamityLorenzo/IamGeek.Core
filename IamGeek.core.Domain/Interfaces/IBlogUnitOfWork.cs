using System;

namespace IamGeek.core.Db.Interfacts
{
    public interface IBlogUnitOfWork :IDisposable
    {
        IPosts Posts { get; }
        IPostsInfo PostInfo { get; }
        ITags Tags {get;}
        void Complete();
    }
}