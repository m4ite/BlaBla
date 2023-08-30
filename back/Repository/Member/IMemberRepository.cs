using back.Model;

public interface IMemberRepository
{
    Task<List<Person>> GetUsers(string title);
    Task<List<MemberDTO>> GetMembers(string title);
    Task<Member> GetMemberUpdate(int userID, string community);
    Task<Person> GetMember(string name);
    Task<Boolean> GetRelation(int id, string title);
    Task<List<Person>> GetAll(int id, string title);
    Task Add(Member obj);
    Task Delete(Member obj);
    Task Update(Member obj);
}