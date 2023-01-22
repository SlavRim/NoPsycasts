namespace NoPsycasts;

partial class Patches
{
    #region Hediff
    [HarmonyPatch(typeof(Pawn_HealthTracker), nameof(AddHediff), new[] { typeof(Hediff), typeof(BodyPartRecord), typeof(DamageInfo?), typeof(DamageWorker.DamageResult) }), HarmonyPrefix]
    public static bool AddHediff(Pawn_HealthTracker __instance, Hediff hediff) // don't allow to add psylink hediff
    {
        if (hediff is not Hediff_Psylink psylink)
            return true;
        psylink.pawn ??= __instance.pawn;
        RemoveHediff(psylink);
        return false;
    }

    [HarmonyPatch(typeof(HediffSet), nameof(ExposeData)), HarmonyPrefix, HarmonyPostfix]
    public static void ExposeData(HediffSet __instance) // remove all psylink hediffs
    {
        var pawn = __instance.pawn;
        var hediffs = __instance.hediffs;
        for (int i = 0; i < hediffs.Count; i++)
        {
            var hediff = hediffs[i];
            if (hediff is not Hediff_Psylink psylink) continue;
            psylink.pawn ??= pawn;
            RemoveHediff(psylink);
        }
    }
    #endregion
}