using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResearch.IdentityServer.TestApp.Structs
{
    public class JWTPayload
    {
        public int nbf { get; set; }
        public int exp { get; set; }
        public string iss { get; set; }
        public List<string> aud { get; set; }
        public string client_id { get; set; }
        public string sub { get; set; }
        public int auth_time { get; set; }
        public string idp { get; set; }
        public string Claim1 { get; set; }
        public string Claim2 { get; set; }
        public List<string> scope { get; set; }
        public List<string> amr { get; set; }
    }
}
