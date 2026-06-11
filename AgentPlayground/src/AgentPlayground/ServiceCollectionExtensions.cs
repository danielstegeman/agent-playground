using System.ComponentModel;
using System.Reflection;
using AgentPlayground.Tools.Clock;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AgentPlayground;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAgentPlaygroundAgent(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<AzureOpenAIOptions>()
            .Bind(configuration.GetSection(AzureOpenAIOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<ClockTools>();

        services.AddSingleton<AIAgent>(sp =>
        {
            var opts = sp.GetRequiredService<IOptions<AzureOpenAIOptions>>().Value;

            var chatClient = new AzureOpenAIClient(
                    new Uri(opts.Endpoint),
                    new DefaultAzureCredential())
                .GetChatClient(opts.DeploymentName)
                .AsIChatClient();

            var instructions = InstructionsLoader.LoadFromResource<AssemblyMarker>(
                "Instructions.MainAgent.md");

            var clockTools = sp.GetRequiredService<ClockTools>();
            IList<AITool> aiTools = typeof(ClockTools)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false).Length > 0)
                .Select(m => (AITool)AIFunctionFactory.Create(m, clockTools))
                .ToList();

            return new ChatClientAgent(
                chatClient,
                instructions: instructions,
                name: "agentplayground",
                tools: aiTools);
        });

        return services;
    }
}
