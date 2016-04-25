using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IamGeek.core.Db.Interfacts;
using IamGeek.core.Domain.Interface;
using IamGeek.core.Domain.DomainModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IamGeek.core.BlogApp.Controllers
{
    [Route("[controller]")]
    public class BlogPostController : Controller
    {
        private ISqlBlogManager _manager;
        public BlogPostController(ISqlBlogManager manager)
        {
            this._manager = manager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var currentTime = DateTime.Now;


            return View(_manager.PostsInfo.GetPostInfoForMonth(currentTime.Year, currentTime.Month));
        }
        [HttpGet("{postName}")]
        public IActionResult ViewPost(string postName)
        {
            if (string.IsNullOrEmpty(postName))
            {
                return HttpNotFound();
            }else
            {
                return View(_manager.Posts.GetPost(postName) ?? BlogPost.Empty());
            }
        }
        [HttpGet("{postId:guid}")]
        public IActionResult ViewPost(Guid postId)
        {
            if (Guid.Empty == postId)
            {
                return HttpNotFound();
            }
            else
            {
                return View(_manager.Posts.GetPost(postId) ?? BlogPost.Empty());
            }
           // return View("ViewPost");
        }
    }
}
