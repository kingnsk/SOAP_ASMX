using ClinicServiceProtos;
using Grpc.Core;
using Grpc.Net.Client;
using static ClinicServiceProtos.AuthenticateService;
using static ClinicServiceProtos.ClinicClientService;

namespace ClinicClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AppContext.SetSwitch(
            //    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            AuthenticateServiceClient authenticateServiceClient = new AuthenticateServiceClient(channel);

            var authenticationResponse = authenticateServiceClient.Login(new AuthenticationRequest
            {
                UserName = "none@none.com",
                Password = "12345"
            });

            if(authenticationResponse.Status != 0)
            {
                Console.WriteLine("Authentication error!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Session token: {authenticationResponse.SessionContext.SessionToken}");

            var callCredentials = CallCredentials.FromInterceptor((c, m) =>
            {
                m.Add("Authorization",
                    $"Bearer {authenticationResponse.SessionContext.SessionToken}");
                return Task.CompletedTask;
            });

            var protectedCahnnel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), callCredentials)
            });

            ClinicClientServiceClient client = new ClinicClientServiceClient(protectedCahnnel);

            var createClientResponse = client.CreateClient(new ClinicServiceProtos.CreateClientRequest
            {
                Document = "PASS 777",
                FirstName = "Констанитн",
                Surname = "Сидоров",
                Patronymic = "Дмитриевич"
            });

            Console.WriteLine($"Client ({createClientResponse.ClientId}) created successfully.");

            var getClientsResponse = client.GetClients(new ClinicServiceProtos.GetClientsRequest());

            Console.WriteLine("Clients:");
            Console.WriteLine("========\n");
            foreach (var clientObj in getClientsResponse.Clients)
            {
                Console.WriteLine($"{clientObj.Document} >> {clientObj.Surname} {clientObj.FirstName}");
            }

            Console.ReadKey();
        }
    }
}