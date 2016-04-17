using System;
using System.Collections.Generic;
using System.Linq;
using GeekBlog.Domain.DomainModel;
using GeekBlog.Domain.DomainModel.Projections;

namespace GeekBlog.Domain.Interfaces
{
    public interface IPostsInfoService
    {
        IEnumerable<int> GetAvailableYears();
        IGrouping<int, PostMonthCounts> GetAvailablePostCountByYear(int year);
        BlogPostInfo GetPostInfo(string url);
        BlogPostInfo GetPostInfo(Guid id);
        IEnumerable<BlogPostInfo> GetPostInfoForMonth(int year, int month);
    }
}