using back.Model;

public interface ISearchRepository
{
    Task<List<Community>> GetCommunities(string searchValue);
}