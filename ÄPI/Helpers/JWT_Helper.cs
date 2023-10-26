using ÄPI.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ÄPI.Helpers
{
    public class JWT_Helper
    {
        private IConfiguration _configuration;

        public JWT_Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(int userID) //Generates token with the userID included on it.
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
                new Claim(ClaimTypes.NameIdentifier, userID.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GetUserIDFromToken(string token) //From the assigned token, obtains its userID.
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var claims = securityToken.Claims;
            var userIdClaim = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            return userIdClaim.Value;
        }
    }
}
