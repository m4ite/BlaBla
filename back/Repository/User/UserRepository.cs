using System.Linq.Expressions;
using back.Model;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private BlablaContext ctx;
    public UserRepository(BlablaContext service)
        => this.ctx = service;
    public async Task Add(Person obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Person>> Filter(Expression<Func<Person, bool>> exp)
    {
        return await ctx.People
            .Where(exp)
            .ToListAsync();
    }

    public async Task Delete(Person obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Person obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<Person> GetUser(int userId)
    {
        var query = from user in ctx.People
                    where user.Id == userId
                    select user;

        var person = await query.FirstOrDefaultAsync<Person>();
        return person;
    }

    public async Task<List<Person>> GetAllUsers()
    {
        var query = from user in ctx.People select user;
        var users = await query.ToListAsync();

        return users;
    }
}