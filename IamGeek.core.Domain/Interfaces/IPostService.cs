using IamGeek.core.Domain.DomainModel;
using System;

namespace IamGeek.core.Db.Interfacts
{
    public interface IPostService
    {
        BlogPost GetPost(Guid Id);
        BlogPost GetPost(string Url);
        void UpdatePost(BlogPost updatedPost);
        void AddPost(BlogPost AddPost);
    }
}