using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;

namespace Smart_Strength_Backend.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public PostsService PostsService { get; private set; }

        public PostsController()
        {
            this.PostsService = new PostsService();
        }
        [HttpGet]
        [Route("get")]
        public async Task<Post[]> GetPosts()
        {
            try
            {
                Post[] posts = await this.PostsService.GetPosts();
                return posts;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
