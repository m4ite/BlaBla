using back.Model;

public interface IPostRepository
{
    Task<List<PostDTO>> GetPostsByCommunity(string title);
    Task<List<PostDTO>> GetPosts();
    Task<Post> GetPost(string postTitle);
    Task Add(Post obj);
    Task Delete(Post obj);
    Task Update(Post obj);
}