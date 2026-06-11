using System.Reflection;

namespace AgentPlayground;

public static class InstructionsLoader
{
    /// <summary>
    /// Loads an embedded markdown file by manifest-name suffix.
    /// Example: <c>LoadFromResource&lt;AssemblyMarker&gt;("Instructions.MainAgent.md")</c>.
    /// </summary>
    public static string LoadFromResource<TAssemblyMarker>(string resourceNameSuffix)
    {
        var asm = typeof(TAssemblyMarker).Assembly;
        var name = asm.GetManifestResourceNames()
            .SingleOrDefault(n => n.EndsWith(resourceNameSuffix, StringComparison.Ordinal))
            ?? throw new InvalidOperationException(
                $"Embedded resource '{resourceNameSuffix}' not found in {asm.GetName().Name}. " +
                "Did you forget <EmbeddedResource> in the csproj?");

        using var stream = asm.GetManifestResourceStream(name)!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
