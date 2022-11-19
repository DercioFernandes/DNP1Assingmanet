using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPIv1.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic logic;

    public PostController(IPostLogic logic)
    {
        this.logic = logic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDTO dto)
    {
        try
        {
            Post post = await logic.CreateAsync(dto);
            return Created($"/users/{post.idPost}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] int? idCreator)
    {
        try
        {
            SearchPostParametersDTO parameters = new(idCreator);
            IEnumerable<Post> posts = await logic.GetAsync(parameters);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}