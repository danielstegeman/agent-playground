using System.ComponentModel.DataAnnotations;

namespace AgentPlayground;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";

    [Required]
    public string Endpoint { get; set; } = string.Empty;

    [Required]
    public string DeploymentName { get; set; } = string.Empty;
}
