using IamGeek.core.Db.Interfacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IamGeek.core.Domain.Interface
{
    public interface IBlogManager
    {
        IPostService Posts { get; }
        IPostsInfoService PostsInfo { get; }
        ITagsService Tagging { get; }
    }

    public interface ISqlBlogManager: IBlogManager
    {

    }
}
