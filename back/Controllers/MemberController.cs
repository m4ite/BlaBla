using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Security.Jwt;

using back.Model;

namespace back.Controllers;


[ApiController]
[Route("member")]
[EnableCors("MainPolicy")]
public class MemberController : ControllerBase
{
    [HttpGet("{title}")]
    public async Task<ActionResult<List<Person>>> GetUser(
        [FromServices] IMemberRepository repo,
        string title
    )
    {
        var query = await repo.GetUsers(title);
        return query;
    }




    [HttpGet("list/{title}")]
    public async Task<ActionResult> GetMember(
        [FromServices] IMemberRepository repo,
        string title
    )
    {
        var query = await repo.GetMembers(title);
        return Ok(query);
    }




    [HttpGet("member/{name}")]
    public async Task<ActionResult<Person>> GetMemberByName(
        [FromServices] IMemberRepository repo,
        string name
    )
    {
        var query = await repo.GetMember(name);
        return query;
    }


    [HttpGet("getRelation/{jwt}/{communityTitle}")]
    public async Task<ActionResult<Boolean>> GetRelation(
       [FromServices] IMemberRepository repo,
       [FromServices] JwtService service,
       string jwt,
       string communityTitle
   )
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        var query = await repo.GetRelation(id, communityTitle);
        return query;
    }


    [HttpGet("getAll/{jwt}/{communityTitle}")]
    public async Task<ActionResult<List<Person>>> GetAll(
        [FromServices] IMemberRepository repo,
        [FromServices] JwtService service,
        string jwt,
        string communityTitle
    )
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        var query = await repo.GetAll(id, communityTitle);
        return query;
    }






    [HttpPost("create/{jwt}")]
    public async Task<ActionResult> Add(
         [FromBody] Community community,
         [FromServices] IMemberRepository repo,
         [FromServices] ICommunityRepository communityRepo,
         string jwt,
         [FromServices] JwtService service
    )
    {
        Member member = new Member();

        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;
        member.Person = id;

        var query = await communityRepo.GetAllCommunities();
        foreach (var com in query)
        {
            if (com.Title == community.Title)
            {
                member.Community = com.Id;
            }

        }
        member.Cargo = 3;

        await repo.Add(member);
        return Ok();
    }


    [HttpPost("update/{cargo}/{communityName}")]
    public async Task Update(
        [FromBody] Person user,
        [FromServices] IMemberRepository repo,
        [FromServices] ICargoRepository CargoRepo,
        string cargo,
        string communityName
    )
    {
        var person = await repo.GetMember(user.NickName);

        var member = await  repo.GetMemberUpdate(person.Id, communityName);
        var c = await  CargoRepo.GetCargobyName(cargo);

        member.Cargo = c.Id;

        await repo.Update(member);
    }



}