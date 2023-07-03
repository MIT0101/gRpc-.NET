
using Grpc.Net.Client;
using Grpc_Client_Demo;


var channel = GrpcChannel.ForAddress("http://localhost:5168");
var client = new Greeter.GreeterClient(channel);

Console.WriteLine("Press Any Key To Test .....");
Console.ReadLine();

/*can add headers like authorization etc..
 * 
 * using Grpc.Core;
 * var headers = new Metadata();
 * headers.Add("Authorization", "Bearer <token>");
 * var response = await client.SayMyNameAsync(new MyRequestMessage { MyMessage = "Mohammed" },headers:headers);
 */

var response = await client.SayMyNameAsync(new MyRequestMessage { MyMessage = "Mohammed" });
Console.WriteLine(response);

Console.WriteLine("Press Any Key To Close .....");
Console.ReadLine();


/*******************************------------Complex Example---------*********************************************/
/*
using System.Diagnostics;
Console.WriteLine("Write any thing to start ..");

using var channel = GrpcChannel.ForAddress("http://localhost:5168");

var client = new Greeter.GreeterClient(channel);

string read = Console.ReadLine();

var stopWatch = Stopwatch.StartNew();
while (read != "q")
{
    try
    {

        stopWatch = Stopwatch.StartNew();
        var response = await client.SayMyNameAsync(new MyRequestMessage { MyMessage = read });
        Console.WriteLine("Response is {0}", response.MyResponse);
        Console.WriteLine("Response with {0} Ms", stopWatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("------------------------------------");
        stopWatch.Restart();
        read = Console.ReadLine();
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
        break;
    }

}
*/
