using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using back.Model;

namespace back.Controllers;

[ApiController]
[Route("search")]
[EnableCors("MainPolicy")]
public class SearchController : ControllerBase
{
    [HttpGet("{searchValue}")]
    public async Task<ActionResult<List<Community>>> GetCommunities(
        [FromServices] ISearchRepository repo,
        string searchValue
    )
    {
        var communities = await repo.GetCommunities(searchValue);
        return communities;
    }
}