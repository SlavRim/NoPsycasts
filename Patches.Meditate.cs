namespace NoPsycasts;

partial class Patches
{
    [HarmonyPatch(typeof(MeditationUtility), nameof(CanMeditateNow)), HarmonyPrefix]
    public static bool CanMeditateNow(ref bool __result) => __result = false; // don't allow meditation (used in most of the game methods)

    #region Time Assignment
    [HarmonyPatch(typeof(TimeAssignmentSelector), nameof(DrawTimeAssignmentSelectorFor)), HarmonyPrefix]
    public static bool DrawTimeAssignmentSelectorFor(TimeAssignmentDef ta) => ta != TimeAssignmentDefOf.Meditate; // don't draw time assignment of meditation

    [HarmonyPatch(typeof(Pawn_TimetableTracker), nameof(ExposeData)), HarmonyPrefix, HarmonyPostfix]
    public static void ExposeData(Pawn_TimetableTracker __instance) // replace all meditation assignments
    {
        var times = __instance.times;
        for (int i = 0; i < __instance.times.Count; i++)
        {
            if(times[i] == TimeAssignmentDefOf.Meditate)
                times[i] = TimeAssignmentDefOf.Anything;
        }
    }
    #endregion
}