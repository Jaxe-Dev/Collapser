using Harmony;
using Verse;

namespace Collapser
{
    [StaticConstructorOnStartup]
    internal static class Main
    {
        static Main() => HarmonyInstance.Create("Collapser").PatchAll();
    }
}
