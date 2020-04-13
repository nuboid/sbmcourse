using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyResearch.Auth.JWTToken.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyAsString = @"@h9y+Xuk(w]+sjaprqw9v8R*'RK343wVPr}{dEuA[9HxqDq ? Fx < f_] zpP_`E ~@7.Lk+zCL'gKWzKw;5:2xb~8x\Akp#*4mcM}6&8.`&B+4Eg[r!n2`_`9/EHbqmLE";
            //var keyAsString = @"Euh, I do not have the key";
            var keyAsBytes = Encoding.UTF8.GetBytes(keyAsString);
            var fromIssuer = "MeAsGenerator";
            var forAudience = "OtherPartyAsAudience";


            var tokenAsText = File.ReadAllText(Environment.CurrentDirectory + @"\..\..\..\..\MyResearch.Auth.JWTToken.Generator\bin\Debug\netcoreapp3.1\jwttoken.txt");
            Console.WriteLine(tokenAsText);
            Console.WriteLine();

            var jwtHandler = new JwtSecurityTokenHandler();

            var token = jwtHandler.ReadJwtToken(tokenAsText);

            Console.WriteLine(token.ToString());
            Console.WriteLine();

            TokenValidationParameters validationParameters =
                new TokenValidationParameters
                {
                    ValidIssuer = fromIssuer,
                    ValidAudiences = new[] { forAudience },
                    IssuerSigningKey = new SymmetricSecurityKey(keyAsBytes)
                };


            SecurityToken validatedToken;

            try
            {
                ClaimsPrincipal user = jwtHandler.ValidateToken(
                                                  tokenAsText,
                                                  validationParameters,
                                                  out validatedToken);

                
                Console.WriteLine(validatedToken.ToString());
                Console.WriteLine();
                Console.WriteLine("Identity.Name : " +user.Identity.Name);
                Console.WriteLine();
                Console.WriteLine("Has Claim1 : " + user.HasClaim(c => c.Type == "SomeClaim1"));
                Console.WriteLine("Value of Claim2 : " + user.Claims.Where(c => c.Type == "SomeClaim2").FirstOrDefault().Value);
                Console.WriteLine("Has Claim3 : " + user.HasClaim(c => c.Type == "SomeClaim3"));


            }
            catch (SecurityTokenInvalidSignatureException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
