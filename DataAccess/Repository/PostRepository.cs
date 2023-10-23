using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            post.DateCreated = DateTime.Now;
            post.LastModified = DateTime.Now;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == postId);

            if (post == null)
            {
                return;
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();
        }   

        public async Task<ICollection<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(post => post.Id == postId);
        }

        public async Task<Post> UpdatePostAsync(string updatedContent, int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == postId);

            post.LastModified = DateTime.Now;
            post.Content = updatedContent;

            await _context.SaveChangesAsync();

            return post;
        }
    }
}