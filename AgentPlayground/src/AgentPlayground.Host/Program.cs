using AgentPlayground;
using Microsoft.Agents.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets<Program>(optional: true);

builder.Services.AddAgentTelemetry(builder.Configuration);
builder.Services.AddAgentPlaygroundAgent(builder.Configuration);

using var host = builder.Build();
var agent = host.Services.GetRequiredService<AIAgent>();

Console.WriteLine("AgentPlayground — chat with the agent. Type 'exit' to quit.");
var session = await agent.CreateSessionAsync();

while (true)
{
    Console.Write("\nyou> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) ||
        input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    Console.Write("bot> ");
    await foreach (var update in agent.RunStreamingAsync(input, session))
    {
        Console.Write(update.Text);
    }

    Console.WriteLine();
}
