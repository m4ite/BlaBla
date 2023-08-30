using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Security.Jwt;

using back.Model;

namespace back.Controllers;


[ApiController]
[Route("community")]
[EnableCors("MainPolicy")]
public class CommunityController : ControllerBase
{
    [HttpPost("create/{jwt}")]
    public async Task<ActionResult> Add(
           [FromBody] Community community,
           [FromServices] ICommunityRepository repo,
           [FromServices] IMemberRepository memberRepo,
           string jwt,
           [FromServices] JwtService service
       )
    {
        var data = service.Validate<UserData>(jwt);

        var comunnities = await repo.GetAllCommunities();

        foreach (var c in comunnities)
        {
            if (c.Title == community.Title)
                return BadRequest("Já existe uma comunidade com esse nome!");
        }

        int id = data.UserId;

        await repo.Add(community);

        Member member = new Member();
        member.Person = id;
        member.Community = community.Id;
        member.Cargo = 3;

        await memberRepo.Add(member);
        return Ok();
    }




    [HttpGet("{jwt}")]
    public async Task<ActionResult<List<Community>>> GetAll(
        [FromServices] ICommunityRepository repo,
        [FromServices] JwtService service,
        string jwt
    )
    {
        var data = service.Validate<UserData>(jwt);
        if (data is null)
            return Forbid();

        int id = data.UserId;
        var communities = await repo.GetCommunities(id);
        return communities;
    }





    [HttpGet("manage/{title}")]
    public async Task<ActionResult<Community>> GetCommunity(
        [FromServices] ICommunityRepository repo,
        string title
    )
    {
        var query = await repo.GetCommunity(title);
        return query;
    }



    [HttpGet("manage/result/{title}")]
    public async Task<ActionResult> GetCommunityReult(
        [FromServices] ICommunityRepository repo,
        string title
    )
    {
        var query = await repo.GetCommunityResult(title);
        return Ok(query);
    }
}