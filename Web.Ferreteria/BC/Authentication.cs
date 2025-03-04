using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BC
{
    public static class Authentication
    {
        public static byte[] GenerateHash(string contrasenia)
        {
            using (SHA256 shaHash = SHA256.Create())
            {
                byte[] bytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
                return bytes;
            }
        }

        public static string GetHash(byte[] hash)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static JwtSecurityToken? readToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            return jsonToken;
        }

        public static List<Claim> GenerateClaims(JwtSecurityToken? jwtToken, string accessToken)
        {
            var claims = new List<Claim>();

            var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdUsuario");
            if (idClaim != null)
                claims.Add(new Claim(ClaimTypes.NameIdentifier, idClaim.Value));

            var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "usuario");
            if (emailClaim != null)
                claims.Add(new Claim(ClaimTypes.Email, emailClaim.Value));
            claims.Add(new Claim("usuario", emailClaim.Value));
            var emailPart = emailClaim.Value.Split('@')[0];
            claims.Add(new Claim(ClaimTypes.Name, emailPart));

            if (idClaim != null)
                claims.Add(new Claim(ClaimTypes.NameIdentifier, idClaim.Value));

            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            if (roleClaim != null)
                claims.Add(new Claim(ClaimTypes.Role, roleClaim.Value));

            var nombreRolClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "NombreRol");
            if (nombreRolClaim != null)
                claims.Add(new Claim("NombreRol", nombreRolClaim.Value));

            claims.Add(new Claim("Token", accessToken));
            return claims;
        }
    }
}
