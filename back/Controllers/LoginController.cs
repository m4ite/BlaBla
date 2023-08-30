using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using back.Model;
using Security.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace back.Controllers;

[ApiController]
[Route("login")]
[EnableCors("MainPolicy")]
public class LoginController : ControllerBase
{
    [HttpPost("entrar")]
    public async Task<ActionResult<string>> Login(
        [FromBody]Login user, 
        [FromServices]IUserRepository repo,
        [FromServices]JwtService jwt)
    {        
        var queryEmail = await repo.Filter(u => u.Email == user.Email);
        var sla = queryEmail.FirstOrDefault();
        var HashUser = Hash(user.WordPass, sla!.Salt!);

        var myUser = queryEmail.FirstOrDefault();

        if(myUser!.WordPass != HashUser)
            return Ok();
        
        UserData data = new UserData();
        data.UserId = myUser.Id;

        var token = jwt.GetToken(data);
        return Ok(new { 
            token = token 
        });
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


 