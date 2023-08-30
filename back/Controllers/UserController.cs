using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using back.Model;
using System.Security.Cryptography;
using System.Text;
using Security.Jwt;

namespace back.Controllers;


[ApiController]
[Route("user")]
[EnableCors("MainPolicy")]
public class UserController : ControllerBase
{
    [HttpGet("{jwt}")]
    public async Task<ActionResult<Person>> GetUser(
        [FromServices] IUserRepository repo,
        string jwt,
        [FromServices] JwtService service
    )
    {
        var data = service.Validate<UserData>(jwt);
        int id = data.UserId;

        var query = await repo.GetUser(id);
        return query;
    }


    [HttpPost("sign")]
    public async Task<ActionResult> Add([FromBody] UserDTO user, [FromServices] IUserRepository repo)
    {

        var users = await repo.GetAllUsers();
        foreach (var u in users)
        {
            if (u.Email == user.Email)
                return BadRequest("Usuário já cadastrado");
        }


        string salt = Salt();

        Person newUser = new Person();

        newUser.BirthDate = user.BirthDate;
        newUser.Email = user.Email;
        newUser.Foto = user.Foto;
        newUser.NickName = user.NickName;
        newUser.Salt = salt;
        newUser.WordPass = Hash(user.WordPass, salt);


        await repo.Add(newUser);
        return Ok();
    }

    protected string Salt()
    {

        byte[] array = new byte[12];
        Random.Shared.NextBytes(array);
        string salt = Convert.ToBase64String(array);

        return salt;
    }

    protected string Hash(string password, string salt)
    {
        var a = password + salt;
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(a);
        var hashBytes = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hashBytes);
    }

}