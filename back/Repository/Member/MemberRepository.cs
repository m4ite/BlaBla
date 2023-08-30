using back.Model;
using Microsoft.EntityFrameworkCore;

public class MemberRepository : IMemberRepository
{
    private BlablaContext ctx;
    public MemberRepository(BlablaContext service)
        => this.ctx = service;
    public async Task Add(Member obj)
    {
        await ctx.AddAsync(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Delete(Member obj)
    {
        ctx.Remove(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task Update(Member obj)
    {
        ctx.Update(obj);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Person>> GetUsers(string title)
    {

        var query =
            from m in ctx.Members
            join c in ctx.Communities
            on m.Community equals c.Id
            join p in ctx.People
            on m.Person equals p.Id
            where c.Title == title
            select p;

        
        var members = await query.ToListAsync();
        return members;
    }

    public async Task<List<MemberDTO>> GetMembers(string title)
    {
        var query = ctx.Members
            .Include(c => c.PersonNavigation)
            .Include(c => c.CommunityNavigation)
            .Include(c => c.CargoNavigation)
            .Where(m => m.CommunityNavigation.Title == title)
            .Select(m => new MemberDTO { 
                NickName = m.PersonNavigation.NickName,
                Foto = m.PersonNavigation.Foto,
                Cargo = m.CargoNavigation.Nome
            });

        var members = await query.ToListAsync();
        
        return members;
    }




    public async Task<Person> GetMember(string name)
    {
        var user =
            from p in ctx.People
            where p.NickName == name
            select p;

        var result = await user.FirstOrDefaultAsync<Person>();
        return result;
    }

    public async Task<Boolean> GetRelation(int id, string title)
    {
        var query = from m in ctx.Members
                    join c in ctx.Communities
                    on m.Community equals c.Id
                    join p in ctx.People
                    on m.Person equals p.Id
                    select m;

        var member = await query.ToListAsync();


        var queryC = from c in ctx.Communities 
                    where c.Title == title
                    select c;

        var com = await queryC.FirstOrDefaultAsync();

        foreach (var m in member)
        {
            if(m.Person == id && com.Id == m.Community)
                return true;
        }

        return false;
         
    }


     public async Task<List<Person>> GetAll(int id, string title)
    {
        var query = from m in ctx.Members
                    join c in ctx.Communities
                    on m.Community equals c.Id
                    join p in ctx.People
                    on m.Person equals p.Id
                    where p.Id == id && c.Title == title 
                    select p;

        var member = await query.ToListAsync();
        return member;
         
    }



     public async Task<Member> GetMemberUpdate(int userID, string community)
    {
        var query = ctx.Members
        .Include( c => c.CommunityNavigation)
        .Include( c=> c.PersonNavigation)
        .Where( m => m.PersonNavigation.Id == userID)
        .Where( m => m.CommunityNavigation.Title == community)
        .Select(c => c);

        var result = await query.FirstOrDefaultAsync();
        return result;
    }


}