using HarmonyLib;
using Verse;

namespace Collapser
{
  [StaticConstructorOnStartup]
  internal static class Mod
  {
    public const string Id = "Collapser";
    public const string Name = Id;
    public const string Version = "1.6";

    static Mod() => new Harmony(Id).PatchAll();
  }
}
