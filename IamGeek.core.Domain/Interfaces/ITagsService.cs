using System;
using System.Collections.Generic;

namespace GeekBlog.Domain.Interfaces
{
    public interface ITagsService
    {
        void AddTagsToPost(Guid Id, IEnumerable<string> Tags);
        void AddTagToPost(Guid Id, string Tag);
        IEnumerable<string> GetTagsForPost(Guid Id);
        void RemoveTagFromPost(Guid Id, string Tag);
    }
}