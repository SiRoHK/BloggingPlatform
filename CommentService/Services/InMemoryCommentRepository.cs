using Common.Models;

namespace CommentService.Repositories
{
    public class InMemoryCommentRepository : ICommentRepository
    {
        private readonly List<Comment> _comments = new();

        public Task<Comment> CreateAsync(CreateCommentRequest request)
        {
            var comment = new Comment
            {
                PostId = request.PostId,
                Author = request.Author,
                Text = request.Text
            };

            _comments.Add(comment);
            return Task.FromResult(comment);
        }

        public Task<IEnumerable<Comment>> GetByPostIdAsync(string postId)
        {
            return Task.FromResult(_comments.Where(c => c.PostId == postId));
        }
    }
}