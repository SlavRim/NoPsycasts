namespace NoPsycasts;

[Harmony]
public static partial class Patches 
{
    public static readonly List<string> DisabledRoyaltyFeatures = new()
    {
        "psycast",
        "psyfocus",
        "psylink",
        "meditat"
    };

    [HarmonyPatch(typeof(ModLister), nameof(CheckRoyalty)), HarmonyPrefix]
    public static bool CheckRoyalty(ref bool __result, string featureNameSingular) // patches allowing of psycast features
    {
        featureNameSingular = featureNameSingular.ToLower();
        if (DisabledRoyaltyFeatures.Any(featureNameSingular.Contains))
            return __result = false;
        return true;
    }
}