using GeekBlog.Domain.DomainModel;
using GeekBlog.Domain.DomainModel.Projections;
using GeekBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBlog.Domain.Services
{
    public class PostsInfoService : IPostsInfoService
    {
        private IPostsInfo postInfo;
        public PostsInfoService(IPostsInfo postInfo)
        {
            this.postInfo = postInfo;
        }

       public IEnumerable<int> GetAvailableYears()
        {
            return this.postInfo.GetAllYears();
        }

        public IGrouping<int, PostMonthCounts> GetAvailablePostCountByYear(int year)
        {
            IEnumerable<string> postsForYear  = this.postInfo.GetAllMonthNamesforYear(year);
            return new PostYearMonthCounts(year, from posts in postsForYear
                                                 group posts by posts into grpPosts
                                                 select new PostMonthCounts(grpPosts.Key, grpPosts.Count()));
        }

        public IEnumerable<BlogPostInfo> GetPostInfoForMonth(int year, int month)
        {
            return this.postInfo.GetAllPostsForMonth(year, month);
        }

        public BlogPostInfo GetPostInfo(string url)
        {
            return this.postInfo.GetInfo(url);
        }

        public BlogPostInfo GetPostInfo(Guid id)
        {
            return this.postInfo.GetInfo(id);
        }
    }
}
