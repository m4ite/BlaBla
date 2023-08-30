using back.Model;
using Microsoft.AspNetCore.Mvc;

public interface ILikeRepository
{
    Task Add(Like obj);
    Task Delete(Like obj);
    Task Update(Like obj);
    Task<Like> getLike(int userID, int Postid);
}