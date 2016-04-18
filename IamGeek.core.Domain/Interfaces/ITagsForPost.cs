using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IamGeek.core.Db.Interfacts
{
    public interface ITagsForPost
    {
        IEnumerable<string> AllTags { get; }
        bool TagExists(string TagName);
        void AddTag(string TagName);
        void RemoveTag(string TagName);
    }
}
