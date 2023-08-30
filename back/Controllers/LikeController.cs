using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using back.Model;
using Security.Jwt;

namespace back.Controllers;

[ApiController]
[Route("avaliation")]
[EnableCors("MainPolicy")]
public class LikeController : ControllerBase
{
    [HttpPost("like/{jwt}")]
    public async Task<ActionResult> Like(
        [FromServices] ILikeRepository repo,
        [FromServices] IMemberRepository memberRepo,
        [FromServices] IPostRepository postRepo,
        [FromBody] PostDTO post,
        [FromServices] JwtService service,
        string jwt
        )
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        Like like = new Like();

        like.Person = id;


        var p = await postRepo.GetPost(post.Title);

        like.Post = p.Id;

        await repo.Add(like);
        return Ok();
    }



    [HttpPost("deslike/{jwt}")]
    public async Task<ActionResult> Deslike(
        [FromServices] ILikeRepository repo,
        [FromServices] IMemberRepository memberRepo,
        [FromServices] IPostRepository postRepo,
        [FromBody] PostDTO post,
        [FromServices] JwtService service,
        string jwt
        )
    {
        var data = service.Validate<UserData>(jwt);
        int Userid = data.UserId;

        var p = await postRepo.GetPost(post.Title);
        int Postid = p.Id;

        var like = await repo.getLike(Userid, Postid);

        await repo.Delete(like);
        return Ok();
    }

}

