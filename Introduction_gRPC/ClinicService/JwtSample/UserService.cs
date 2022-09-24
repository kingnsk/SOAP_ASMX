﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtSample
{
    internal class UserService
    {
        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"root1", "test" }, // id = 0
            {"root2", "test" }, // id = 1
            {"root3", "test" }, // id = 2
            {"root4", "test" } //  id = 3
        };

        private const string SecretCode = "u8989DFVD0--dF$#++";

        public string Authenticate(string user, string password)
        {
            if(string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            int i = 0;
            foreach (KeyValuePair<string, string> pair in _users)
            {
                if(string.CompareOrdinal(pair.Key, user) == 0 &&
                    string.CompareOrdinal(pair.Value, password) == 0)
                {
                    return GenerateJwtToken(i);
                }
                i++;
            }

            return null;
        }

        private string GenerateJwtToken(int id)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Expires = DateTime.Now.AddMinutes(30);
            securityTokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())    
            
            });
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha384Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
        
    }
}
