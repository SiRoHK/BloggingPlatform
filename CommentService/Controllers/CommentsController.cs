using Common.Models;
using CommentService.Repositories;
using CommentService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IPostServiceClient _postServiceClient;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(
            ICommentRepository repository,
            IPostServiceClient postServiceClient,
            ILogger<CommentsController> logger)
        {
            _repository = repository;
            _postServiceClient = postServiceClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Create(CreateCommentRequest request)
        {
            // Validate that post exists
            bool postExists = await _postServiceClient.PostExistsAsync(request.PostId);
            if (!postExists)
            {
                _logger.LogWarning("Attempted to comment on non-existent post: {PostId}", request.PostId);
                return NotFound($"Post with ID {request.PostId} not found");
            }

            var comment = await _repository.CreateAsync(request);
            _logger.LogInformation("Created comment for post: {PostId}", request.PostId);
            return CreatedAtAction(nameof(GetByPostId), new { postId = comment.PostId }, comment);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByPostId(string postId)
        {
            // Optional: validate that post exists first
            bool postExists = await _postServiceClient.PostExistsAsync(postId);
            if (!postExists)
            {
                return NotFound($"Post with ID {postId} not found");
            }

            return Ok(await _repository.GetByPostIdAsync(postId));
        }
    }
}