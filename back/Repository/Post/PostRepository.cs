using back.Model;
using Microsoft.EntityFrameworkCore;

public class PostRepository : IPostRepository
{
    private BlablaContext ctx;
    public PostRepository(BlablaContext service)
        => this.ctx = service;

    public async Task Add(Post obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Post obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Post obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<PostDTO>> GetPosts()
    {
        var query = ctx.Posts
            .Include(c => c.Person)
            .Include(c => c.Community)
            .Select( m => new PostDTO {
                NickName = m.Person.NickName,
                CommunityPhoto = m.Community.Foto,
                Community = m.Community.Title,
                Title = m.Title,
                Description = m.Descrip,
                Foto = m.Foto
            });
        
        var posts = await query.ToListAsync();
        return posts;
    }

    public async Task<List<PostDTO>> GetPostsByCommunity(string communityName)
    {

         var query = ctx.Posts
            .Include(c => c.Person)
            .Include(c => c.Community)
            .Where( c => c.Community.Title == communityName)
            .Select( m => new PostDTO {
                NickName = m.Person.NickName,
                CommunityPhoto = m.Community.Foto,
                Community = m.Community.Title,
                Title = m.Title,
                Description = m.Descrip,
                Foto = m.Foto
            });

        var posts = await query.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPost(string postTitle)
    {
        var query = from post in ctx.Posts 
            where post.Title == postTitle select post;

        var posts = await query.FirstOrDefaultAsync<Post>();
        return posts;
    }

}