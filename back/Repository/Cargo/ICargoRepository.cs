using System.Linq.Expressions;
using back.Model;

public interface ICargoRepository
{
    Task<List<Cargo>> GetCargos(string communityTitle);
    Task<CargoDTO> GetCargoByUser(string communityName, int userName);
    Task<Cargo> GetCargobyName(string name);
    Task<List<Cargo>> Filter(Expression<Func<Cargo, bool>> exp);
    Task Add(Cargo obj);
    Task Delete(Cargo obj);
    Task Update(Cargo obj);
}