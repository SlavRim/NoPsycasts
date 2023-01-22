global using static NoPsycasts.Extensions;

namespace NoPsycasts;

public static partial class Extensions
{
    public const string LogPrefix = $"[{nameof(NoPsycasts)}] ";
    public static void DebugMessage(object text, Action<string> logAction = null) => (logAction ??= Log.Message).Invoke(LogPrefix+text);
    public static void RemoveDef<T>(ref T def) where T : Def
    {
        DefDatabase<T>.defsList.Remove(def);
        def = null;
    }
    public static void RemoveHediff(Hediff_Psylink psylink)
    {
        var pawn = psylink.pawn;
        var count = psylink.level;
        for (int j = 0; j < count; j++)
        {
            var thing = ThingMaker.MakeThing(ThingDefOf.PsychicAmplifier, null);
            pawn.inventory.TryAddItemNotForSale(thing);
        }
    }
}