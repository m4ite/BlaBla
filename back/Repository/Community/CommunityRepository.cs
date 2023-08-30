
using back.Model;
using Microsoft.EntityFrameworkCore;

public class CommunityRepository : ICommunityRepository
{
    private BlablaContext ctx;
    public CommunityRepository(BlablaContext service)
        => this.ctx = service;
    public async Task Add(Community obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Community obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Community obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Community>> GetCommunities(int userId)
    {

        var query = from m in ctx.Members
                    join p in ctx.People
                    on m.Person equals p.Id
                    join c in ctx.Communities
                    on m.Community equals c.Id
                    where m.Person == userId
                    select c;

        var communities = await query.ToListAsync();

        return communities;
    }




    public async Task<Community> GetCommunity(string title)
    {
        var query = from com in ctx.Communities
                    where com.Title == title
                    select com;

        var comunnity = await query.FirstOrDefaultAsync<Community>();
        return comunnity;
    }



    public async Task<CommunityDTO> GetCommunityResult(string title)
    {
        var query = ctx.Members
                    .Include(c => c.CommunityNavigation)
                    .Include(c => c.CargoNavigation)
                    .Include(c => c.PersonNavigation)
                    .Where(c => c.CargoNavigation.Nome == "Owner")
                    .Where(c => c.CommunityNavigation.Title == title)
                    .Select(m => new CommunityDTO
                    {
                        Title = m.CommunityNavigation.Title,
                        Description = m.CommunityNavigation.Descrip,
                        Foto = m.CommunityNavigation.Foto,
                        Owner = m.PersonNavigation.NickName
                    });

        var comunnity = await query.FirstOrDefaultAsync<CommunityDTO>();
        return comunnity;
    }

    public async Task<List<Community>> GetAllCommunities()
    {
        var query = from com in ctx.Communities select com;
        var communities = await query.ToListAsync();

        return communities;
    }


}