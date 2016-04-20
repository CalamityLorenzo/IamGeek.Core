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
using IamGeek.core.Db.Manager;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private readonly SqlBlogManager _manager;
        public BlogPostController(SqlBlogManager manager)
        {
            _manager = manager;
        }
        // GET: api/values
        [HttpGet("GetByUrl/{PostUrl}")]
        public IActionResult Get(string PostUrl)
        {
            if (!string.IsNullOrEmpty(PostUrl))
            {
                return Ok(_manager.Posts.GetPost(PostUrl));
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
                return Ok(_manager.Posts.GetPost(PostId.Value));
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
