using back.Model;
using Microsoft.EntityFrameworkCore;

public class LikeRepository : ILikeRepository
{
    private BlablaContext ctx;
    public LikeRepository(BlablaContext service)
        => this.ctx = service;

    public async Task Add(Like obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Like obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Like obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<Like> getLike(int userID, int Postid)
    {
       var query = from l in ctx.Likes 
                    where l.Person == userID && l.Post == Postid
                    select l;

        var like = await query.FirstOrDefaultAsync<Like>();

        return like;
    }


}