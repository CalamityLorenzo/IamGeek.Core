using IamGeek.core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IamGeek.core.Db.Interfacts;
using IamGeek.core.Db.Repositories;
using IamGeek.core.Domain.Services;

namespace IamGeek.core.Db.Manager
{
    public class SqlBlogManager : ISqlBlogManager
    {

        private readonly IBlogUnitOfWork blogUnit;
        
        public SqlBlogManager(IBlogUnitOfWork blogUnit)
        {
            this.blogUnit = blogUnit;
            this.Posts = new PostService(blogUnit.Posts);
            this.PostsInfo = new PostsInfoService(blogUnit.PostInfo);
            this.Tagging = new TagsService(blogUnit.Tags);
        }

        public IPostService Posts { get; }

        public IPostsInfoService PostsInfo { get; }

        public ITagsService Tagging { get; }
    }
}
