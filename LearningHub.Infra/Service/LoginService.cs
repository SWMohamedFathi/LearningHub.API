using LearningHub.Core.Data;
using LearningHub.Core.Repoistory;
using LearningHub.Core.Service;
using LearningHub.Infra.Repoistory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public string GenearteToken(Login login) // return token value 
        {
            var identity = loginRepository.GenearteToken(login); // return roleid and username if they match

            if (identity == null)
            {

                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"));//Encode header + payload of token 
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, identity.Username),
                   new Claim(ClaimTypes.Role, identity.Roledid.ToString())
                };

                var tokeOptions = new JwtSecurityToken(
                                    claims: claims,
                                     expires: DateTime.Now.AddHours(24),
                                     signingCredentials: signinCredentials
                        );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);//
                return tokenString;

            }
        }
    }
}