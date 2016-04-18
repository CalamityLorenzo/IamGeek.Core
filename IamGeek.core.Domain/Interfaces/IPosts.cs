using IamGeek.core.Domain.DomainModel;
using System;

namespace IamGeek.core.Db.Interfacts
{
    public interface IPosts
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost post);
        void AddPost(BlogPost newPost);
    }
}