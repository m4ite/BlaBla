using back.Model;
using System.Linq.Expressions;

public interface IUserRepository
{
    Task<Person> GetUser(int userId);
    Task<List<Person>> GetAllUsers();
    Task<List<Person>> Filter(Expression<Func<Person, bool>> exp);
    Task Add(Person obj);
    Task Delete(Person obj);
    Task Update(Person obj);
}