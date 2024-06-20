using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenOptions tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        public AccessToken CreateToken(BaseUser baseUser, List<OperationClaim> operationClaims)
        {
            DateTime expirationTime = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwt =
                new(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: expirationTime,
                notBefore: DateTime.Now,
                claims: SetAllClaims(baseUser, operationClaims.Select(i => i.Name).ToList()),
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken()
            {
                Token = jwtToken,
                Expiration = expirationTime
            };
        }
        protected IEnumerable<Claim> SetAllClaims(BaseUser baseUser, List<string> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, baseUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, baseUser.FirstName));
            claims.Add(new Claim(ClaimTypes.Email, baseUser.Email));

            foreach (var operationClaim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, operationClaim));
            }

            return claims;
        }
    }
}
