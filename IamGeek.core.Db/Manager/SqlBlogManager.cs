using IamGeek.core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IamGeek.core.Db.Interfacts;
using IamGeek.core.Db.Repositories;
using IamGeek.core.Domain.Services;
using IamGeek.core.Db.UnitOfWork;

namespace IamGeek.core.Db.Manager
{
    public class SqlBlogManager : ISqlBlogManager
    {

        private readonly IBlogUnitOfWork blogUnit;
        
        public SqlBlogManager(IBlogUnitOfWork blogUnit)
        {
            this.blogUnit = blogUnit;
            this.Posts = new PostService(this.blogUnit.Posts);
            this.PostsInfo = new PostsInfoService(this.blogUnit.PostInfo);
            this.Tagging = new TagsService(this.blogUnit.Tags);
        }

        public SqlBlogManager(ISqlBlogUnitOfWork blogUnit)
        {
            this.blogUnit = blogUnit; // as IBlogUnitOfWork;
            this.Posts = new PostService(this.blogUnit.Posts);
            this.PostsInfo = new PostsInfoService(this.blogUnit.PostInfo);
            this.Tagging = new TagsService(this.blogUnit.Tags);
        }

        public IPostService Posts { get; }

        public IPostsInfoService PostsInfo { get; }

        public ITagsService Tagging { get; }
    }
}
