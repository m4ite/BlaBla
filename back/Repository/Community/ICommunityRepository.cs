using back.Model;
using Microsoft.AspNetCore.Mvc;

public interface ICommunityRepository
{
    Task<List<Community>> GetCommunities(int userId);
    Task<List<Community>> GetAllCommunities();
    Task<Community> GetCommunity(string title);
    Task<CommunityDTO> GetCommunityResult(string title);
    Task Add(Community obj);
    Task Delete(Community obj);
    Task Update(Community obj);
}