using IamGeek.core.Domain.DomainModel;
using IamGeek.core.Domain.Services;
using System;
using System.Collections.Generic;

namespace IamGeek.core.Db.Interfacts
{
    public interface IPostsInfo
    {
        IEnumerable<int> GetAllYears();
        IEnumerable<BlogPostInfo> GetAllPostsForMonth(int year, int month);
        IEnumerable<string> GetAllMonthNamesforYear(int year);
        BlogPostInfo GetInfo(string url);
        BlogPostInfo GetInfo(Guid id);
    }
}