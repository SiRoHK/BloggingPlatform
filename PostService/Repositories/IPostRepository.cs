using Common.Models;

namespace PostService.Repositories
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(CreatePostRequest request);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(string id);
    }
}