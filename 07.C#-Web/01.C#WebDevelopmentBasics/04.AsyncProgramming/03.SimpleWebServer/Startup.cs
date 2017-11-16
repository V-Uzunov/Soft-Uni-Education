namespace _03.SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 1300;
            var listener = new TcpListener(ipAddress, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening TCP clients at {ipAddress}:{port}");

            Task.Run(async () =>  await ConnectWithTCPListener(listener))
                .GetAwaiter()
                .GetResult();
        }

        private static async Task ConnectWithTCPListener(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                var buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                var message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message.Trim('\0'));

                const string responseMsg = "HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server!";
                var data = Encoding.ASCII.GetBytes(responseMsg);
                await client.GetStream().WriteAsync(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
