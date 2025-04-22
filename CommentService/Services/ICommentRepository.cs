using Common.Models;

namespace CommentService.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(CreateCommentRequest request);
        Task<IEnumerable<Comment>> GetByPostIdAsync(string postId);
    }
}