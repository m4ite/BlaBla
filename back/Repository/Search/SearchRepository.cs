using back.Model;
using Microsoft.EntityFrameworkCore;

public class SearchRepository : ISearchRepository
{
    private BlablaContext ctx;
    public SearchRepository(BlablaContext service)
        => this.ctx = service;

    public async Task<List<Community>> GetCommunities(string searchValue)
    {

        var query =
            from c in ctx.Communities
            where EF.Functions.Like(c.Title, "%" + searchValue + "%") || EF.Functions.Like(c.Descrip, "%" + searchValue + "%")
            select c;
            
        var communities = await query.ToListAsync();
        return communities;
    }

}