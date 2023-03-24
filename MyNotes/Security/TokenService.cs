using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MyNotes.Entities;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyNotes.Security;

public class TokenService{

  public static string GenerateToken(User user){
    
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
    var tokenDescriptor = new SecurityTokenDescriptor{
      Subject = new ClaimsIdentity(new Claim[]{
        new Claim("id", user.Id),
        new Claim("user", user.name),
      }),
      Expires = DateTime.UtcNow.AddHours(2),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)};
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token).ToString(); 
  }
}
