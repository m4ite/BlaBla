using System.Linq.Expressions;
using back.Model;
using Microsoft.EntityFrameworkCore;

public class CargoRepository : ICargoRepository
{
    private BlablaContext ctx;
    public CargoRepository(BlablaContext service)
        => this.ctx = service;

    public async Task<List<Cargo>> Filter(Expression<Func<Cargo, bool>> exp)
    {
        return await ctx.Cargos
            .Where(exp)
            .ToListAsync();
    }

    public async Task Add(Cargo obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Cargo obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Cargo obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Cargo>> GetCargos(string title)
    {

        var query =
            from community in ctx.Communities
            join cargo in ctx.Cargos
            on  community.Id equals cargo.Community  
            where community.Title == title
            select cargo;
        
        var cargos = await query.ToListAsync();
        return cargos;
    }

    public async Task<CargoDTO> GetCargoByUser(string communityName, int userID)
    {
        var query = ctx.Members
                    .Include(c => c.CommunityNavigation)
                    .Include(c => c.CargoNavigation)
                    .Include(c => c.PersonNavigation)
                    .Where(m => m.CommunityNavigation.Title == communityName)
                    .Where( m => m.PersonNavigation.Id == userID)
                    .Select( m => new CargoDTO {
                        Nome = m.CargoNavigation.Nome,
                        EditMembers = m.CargoNavigation.EditMembers,
                        AddPost = m.CargoNavigation.AddPost,
                        CreateCargo = m.CargoNavigation.CreateCargo,
                        EditCommunity = m.CargoNavigation.EditCommunity,
                        DeleteCommunity = m.CargoNavigation.DeleteCommunity
                    });
        
        var result = await query.FirstOrDefaultAsync();
        return result;
    }

    public async Task<Cargo> GetCargobyName(string name)
    {
        var query = from c in ctx.Cargos
        where c.Nome == name
        select c;

        var result = await query.FirstOrDefaultAsync<Cargo>();
        return result;
    }

   
}