using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Authors.Commands.CreateAuthor;
using Post.Application.Authors.Commands.DeleteAuthor;
using Post.Application.Authors.Commands.UpdateAuthor;
using Post.Application.Authors.Queries.GetAuthorById;
using Post.Application.Posts.Queries.GetAuthor;
using Post.Domain.Entity;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await Sender.Send(new GetAuthorQuerys());
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await Sender.Send(new GetAuthorByIdQuery() { AuthorId = id});
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(CreateAuthorCommand authorCommand)
        {
            var createdAuthor = await Sender.Send(authorCommand);
            return CreatedAtAction(nameof(GetById), new {id = createdAuthor.Id}, createdAuthor );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthor, int id)
        {
            if (id != updateAuthor.Id)
            {
                return BadRequest();
            }

            await Sender.Send(updateAuthor); 
            // before is NoContent
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await Sender.Send(new DeleteAuthorCommand { Id = id});
            if (result == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
    
    }
}
