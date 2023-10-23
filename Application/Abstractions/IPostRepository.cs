using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPostsAsync();

        Task<Post> GetPostByIdAsync(int postId);

        Task<Post> CreatePostAsync(Post post);

        Task<Post> UpdatePostAsync(string updatedContent, int postId);

        Task DeletePostAsync(int postId);
    }
}