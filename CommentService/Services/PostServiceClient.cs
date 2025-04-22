using System.Net;

namespace CommentService.Services
{
    public class PostServiceClient : IPostServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PostServiceClient> _logger;

        public PostServiceClient(HttpClient httpClient, ILogger<PostServiceClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> PostExistsAsync(string postId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"posts/{postId}");
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if post exists: {PostId}", postId);
                return false;
            }
        }
    }
}