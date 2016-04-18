using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IamGeek.core.Domain.DomainModel;
using IamGeek.core.Db.Interfacts;
using IamGeek.core.Db.UnitOfWork;
using IamGeek.core.Domain.Services;
using IamGeek.core.Db;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        // GET: api/values
        [HttpGet("GetByUrl/{PostUrl}")]
        public IActionResult Get(string PostUrl)
        {
            if (!string.IsNullOrEmpty(PostUrl))
            {
                using (IBlogUnitOfWork blgUow = UnitOfWorkFactory.Instance.Get("Data Source=.\\SQLEXPRESS;Initial Catalog=pclBlogDb;Integrated Security=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    IPostService postService = new PostService(blgUow.Posts);
                    return new HttpOkObjectResult(postService.GetPost(PostUrl));
                }
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // GET api/values/5
        [HttpGet("GetById/{PostId}")]
        public IActionResult Get(Guid? PostId)
        {
            if (PostId.HasValue && PostId.Value != Guid.Empty)
            {
                using (IBlogUnitOfWork blgUow = UnitOfWorkFactory.Instance.Get("Data Source=.\\SQLEXPRESS;Initial Catalog=pclBlogDb;Integrated Security=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    IPostService postService = new PostService(blgUow.Posts);
                    return new HttpOkObjectResult(postService.GetPost(PostId.Value));
                }
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
