using DatabaseTwo.Models;
using Domain_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_01.Features
{
    public class PostService
    {
        private AppDbContext _db;

        public PostService()
        {
            _db = new AppDbContext();
        }

        public async Task<ResponseModel<List<Post>>> GetAllAsync()
        {
            var posts = await _db.Posts.AsNoTracking().Where(p => p.DeleteFlag == false).ToListAsync();
            if(posts is null)
            {
                return ResponseModel<List<Post>>.Error(400, "Posts Not Found!");
            }
            return ResponseModel<List<Post>>.Success(200, "Get all posts",posts);
        }
    }
}
