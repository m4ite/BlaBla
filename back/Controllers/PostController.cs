using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using back.Model;
using Security.Jwt;

namespace back.Controllers;

[ApiController]
[Route("post")]
[EnableCors("MainPolicy")]
public class PostController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAll(
        [FromServices] IPostRepository repo)
    {
        var posts = await repo.GetPosts();
        return Ok(posts);
    }



    [HttpPost("create/{jwt}/{community}")]
    public async Task<ActionResult> Add(
        [FromBody] addPostDTO post,
        [FromServices] IPostRepository repo,
        [FromServices] ICommunityRepository comRepo,
        string jwt,
        string community,
        [FromServices] JwtService service
    )
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        Post NewPost = new Post();
        NewPost.PersonId = id;

        var com = await comRepo.GetCommunity(community);
        NewPost.CommunityId = com.Id;

        NewPost.Title = post.Title;
        NewPost.Descrip = post.Descrip;
        NewPost.Foto = post.Foto;

        await repo.Add(NewPost);
        return Ok();
    }





    [HttpGet("{communityName}")]
    public async Task<ActionResult<List<PostDTO>>> GetByCommunity(
        [FromServices] IPostRepository repo, string communityName)
    {
        var posts = await repo.GetPostsByCommunity(communityName);
        return posts;
    }
}