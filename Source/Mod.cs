using Harmony;
using Verse;

namespace Collapser
{
    [StaticConstructorOnStartup]
    internal static class Mod
    {
        public const string Id = "Collapser";
        public const string Name = Id;
        public const string Version = "1.2";

        static Mod() => HarmonyInstance.Create(Id).PatchAll();
    }
}
