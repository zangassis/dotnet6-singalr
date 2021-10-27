using Microsoft.AspNetCore.SignalR.Client;

public class MainClient
{
    public static async Task ExecuteAsync()
    {
        //Replace port "7054" with the port running the MainSignalServer project
        var uri = "https://localhost:7054/current-time";

        await using var connection = new HubConnectionBuilder().WithUrl(uri).Build();

        await connection.StartAsync();

        await foreach (var date in connection.StreamAsync<DateTime>("Streaming"))
        {
            Console.WriteLine(date);
        }
    }
}