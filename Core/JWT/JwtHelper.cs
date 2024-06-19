using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Core.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenOptions tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        public AccessToken CreateToken(BaseUser user)
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
                claims: null,
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
    }
}
