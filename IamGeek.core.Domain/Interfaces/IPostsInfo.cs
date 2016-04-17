using GeekBlog.Domain.DomainModel;
using GeekBlog.Domain.Services;
using System;
using System.Collections.Generic;

namespace GeekBlog.Domain.Interfaces
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