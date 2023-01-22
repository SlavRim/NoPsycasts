global using Mod = NoPsycasts.Mod;

namespace NoPsycasts;

public sealed class Mod : Verse.Mod
{
    public static Mod Instance { get; private set; }
    public readonly Harmony Harmony = new(nameof(NoPsycasts));
    public Mod(ModContentPack content) : base(content)
    {
        Instance = this;
    }
    internal void OnStartup()
    {
        try
        {
            DebugMessage("Patching.");
            Harmony.PatchAll();
            DebugMessage("Removing related defs.");
            RemoveRelatedDefs();
            DebugMessage("Loaded successfully.");
        }
        catch (Exception ex)
        {
            DebugMessage("Failed to load.", Log.Error);
            Harmony.UnpatchAll(Harmony.Id);
            DebugMessage(ex, Log.Error);
        }
    }
    public static void RemoveRelatedDefs()
    {
        RemoveDef(ref ThingDefOf.MeditationSpot);
    }
}
