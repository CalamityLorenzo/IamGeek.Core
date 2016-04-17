using GeekBlog.Domain.DomainModel;
using System;

namespace GeekBlog.Domain.Interfaces
{
    public interface IPostService
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost updatedPost);
        void AddPost(BlogPost AddPost);
    }
}