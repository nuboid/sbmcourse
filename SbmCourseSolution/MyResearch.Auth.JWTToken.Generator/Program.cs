using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace MyResearch.Auth.JWTToken.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyAsString = @"@h9y+Xuk(w]+sjaprqw9v8R*'RK343wVPr}{dEuA[9HxqDq ? Fx < f_] zpP_`E ~@7.Lk+zCL'gKWzKw;5:2xb~8x\Akp#*4mcM}6&8.`&B+4Eg[r!n2`_`9/EHbqmLE";
            var keyAsBytes = Encoding.UTF8.GetBytes(keyAsString);

            var forUserName = "KUCL";
            var fromIssuer = "MeAsGenerator";
            var forAudience = "OtherPartyAsAudience";

            var tokenLifeTime = 60;

            var claims = new Dictionary<string, string>();
            claims.Add("SomeClaim1", "SomeValue");
            claims.Add("SomeClaim2", "SomeOtherValue");

            var jwtToken = GenerateJWT(
                keyAsBytes,
                forUserName,
                claims,
                fromIssuer,
                forAudience,
                tokenLifeTime);

            File.WriteAllText(Environment.CurrentDirectory + @"\jwttoken.txt", jwtToken);
            Console.WriteLine(jwtToken);

            Console.ReadKey();
        }


        private static string GenerateJWT(
            byte[] key,
            string username,
            Dictionary<string, string> claimsDictionary,
            string issuer,
            string audience,
            int tokenLifetime)
        {
            var securityKey = new SymmetricSecurityKey(key);

            var claimsList = new List<Claim>();
            claimsList.Add(new Claim(ClaimTypes.Name, username));
            foreach (var c in claimsDictionary)
            {
                claimsList.Add(new Claim(c.Key,c.Value));
            }
           
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claimsList,
                expires: DateTime.Now.AddMinutes(tokenLifetime),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
