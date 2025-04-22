using Common.Models;

namespace PostService.Repositories
{
    public class InMemoryPostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new();

        public Task<Post> CreateAsync(CreatePostRequest request)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content
            };

            _posts.Add(post);
            return Task.FromResult(post);
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            return Task.FromResult(_posts.AsEnumerable());
        }

        public Task<Post?> GetByIdAsync(string id)
        {
            return Task.FromResult(_posts.FirstOrDefault(p => p.Id == id));
        }
    }
}