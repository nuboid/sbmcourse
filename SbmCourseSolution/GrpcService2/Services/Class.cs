using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService2.Services
{
    public class Class : Cursus.CursusBase
    {
        public override Task<Volg2> Volg(Volg1 request, ServerCallContext context)
        {
            return null;
        }
    }
}
