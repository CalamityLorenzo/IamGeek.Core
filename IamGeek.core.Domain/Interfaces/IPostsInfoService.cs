using System;
using System.Collections.Generic;
using System.Linq;
using IamGeek.core.Domain.DomainModel;
using IamGeek.core.Domain.DomainModel.Projections;

namespace IamGeek.core.Db.Interfacts
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