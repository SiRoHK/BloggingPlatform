namespace CommentService.Services
{
    public interface IPostServiceClient
    {
        Task<bool> PostExistsAsync(string postId);
    }
}