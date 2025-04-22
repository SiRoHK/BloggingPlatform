using Common.Models;
using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;

namespace PostService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostRepository repository, ILogger<PostsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create(CreatePostRequest request)
        {
            var post = await _repository.CreateAsync(request);
            _logger.LogInformation("Created post with ID: {PostId}", post.Id);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(string id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }
    }
}