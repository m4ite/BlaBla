using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using back.Model;
using Security.Jwt;

namespace back.Controllers;

[ApiController]
[Route("cargo")]
[EnableCors("MainPolicy")]
public class CargoController : ControllerBase
{
    [HttpGet("{communityName}")]
    public async Task<ActionResult<List<Cargo>>> GetCargos(
        [FromServices] ICargoRepository repo,
        string communityName)
    {
        var query = await repo.GetCargos(communityName);
        return query;
    }

    [HttpGet("User/{communityName}/{jwt}")]
    public async Task<ActionResult<CargoDTO>> GetCargos(
        [FromServices] ICargoRepository repo,
        [FromServices] JwtService service,
        string communityName,
        string jwt)
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        var query = await repo.GetCargoByUser(communityName, id);

        return query;
    }


    [HttpPost("create/{communityName}")]
    public async Task<ActionResult> Add(
        [FromBody] Cargo cargo,
        [FromServices] ICargoRepository repo,
        [FromServices] ICommunityRepository repoC,
        string communityName)
    {
        var community = await repoC.GetCommunity(communityName);

        cargo.Community = community.Id;
        await repo.Add(cargo);

        return Ok();
    }




    [HttpPost("update/{communityName}")]
    public async Task<ActionResult> Update(
        [FromBody] Cargo cargo,
        [FromServices] ICargoRepository repo,
        [FromServices] ICommunityRepository repoC,
        string communityName)
    {
        var community = await repoC.GetCommunity(communityName);
        var cargoBanco = await repo.Filter(c => c.Nome == cargo.Nome && c.Community == community.Id);
        var update = cargoBanco.FirstOrDefault();

        update = cargo;

        await repo.Update(update);
        return Ok();
    }
}