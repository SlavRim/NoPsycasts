namespace NoPsycasts;

partial class Patches
{
    [HarmonyPatch(typeof(Pawn_AbilityTracker), nameof(ExposeData)), HarmonyPrefix, HarmonyPostfix]
    public static void ExposeData(Pawn_AbilityTracker __instance) => // remove all abilities that is related to psycast
        __instance.abilities?.RemoveAll(x => !GainAbility(x?.def));

    [HarmonyPatch(typeof(Pawn_AbilityTracker), nameof(GainAbility)), HarmonyPrefix]
    public static bool GainAbility(AbilityDef def) => !(def?.IsPsycast ?? true); // don't allow gain psycast abilities
}