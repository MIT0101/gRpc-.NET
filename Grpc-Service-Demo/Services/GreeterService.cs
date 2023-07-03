using Grpc.Core;
using Grpc_Service_Demo;

namespace Grpc_Service_Demo.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public async override Task<MyResponseMessage> SayMyName(MyRequestMessage request, ServerCallContext context)
        {
            return new MyResponseMessage { MyResponse=$"Your Name is {request.MyMessage}"};
        }
    }
}