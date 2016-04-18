using System;
using System.Collections.Generic;
using System.Linq;
using IamGeek.core.Domain.DomainModel;

namespace IamGeek.core.Db.Interfacts
{
    public interface ITags
    {
        IEnumerable<BlogPostTag> GetTags(Guid id);
        IGrouping<string, BlogPostInfo> GetPostsWithTagName(string tagName);
        void AddTagToPost(Guid PostId, IEnumerable<string> Tags);
        void AddTagToPost(Guid PostId, string Tag);
        void RemoveTagFromPost(Guid PostId, string Tag);
        BlogPostTag GetTag(Guid id, string tag);
    }
}
