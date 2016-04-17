using GeekBlog.Domain.DomainModel;
using System;

namespace GeekBlog.Domain.Interfaces
{
    public interface IPosts
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost post);
        void AddPost(BlogPost newPost);
    }
}