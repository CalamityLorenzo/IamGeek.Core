using IamGeek.core.Domain.DomainModel;
using IamGeek.core.Db.Interfacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IamGeek.core.Domain.Services
{
    public class TagsForPostService : ITagsForPost
    {
        private readonly ITags tags;
        private readonly Guid PostId;

        internal TagsForPostService(Guid PostId, ITags tagRepo)
        {
            this.tags = tagRepo;
            this.PostId = PostId;
        }
        private IEnumerable<string> allTags;
        public IEnumerable<string> AllTags
        {
            get
            {
                return allTags ?? (allTags = tags.GetTags(this.PostId).Select(tg => tg.Text));
            }
        }

        public bool TagExists(string TagName)
        {
            var tag = tags.GetTag(this.PostId, TagName);
            if (tag == BlogPostTag.Empty())
            {
                return false;
            }
            return true;
        }

        public void AddTag(string TagName)
        {
            if (!TagExists(TagName))
            {
                this.tags.AddTagToPost(this.PostId, TagName);
            }
        }

        public void RemoveTag(string TagName)
        {
            if (TagExists(TagName))
            {
                this.tags.RemoveTagFromPost(this.PostId, TagName);
            }
        }
    }
}
