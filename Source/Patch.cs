using System;
using System.Linq;
using Harmony;
using RimWorld;
using Verse;

namespace Collapser
{
    [HarmonyPatch(typeof(RoofCollapserImmediate), "DropRoofInCellPhaseTwo")]
    internal static class Patch
    {
        private static void Prefix(IntVec3 c, Map map)
        {
            var roofDef = map.roofGrid.RoofAt(c);
            if (roofDef == null) { return; }
            if (roofDef.filthLeaving != null) { FilthMaker.MakeFilth(c, map, roofDef.filthLeaving); }
            if (roofDef.VanishOnCollapse) { map.roofGrid.SetRoof(c, null); }
            else if (AdjacentUnroofedTiles(c, map) > 0) { map.roofGrid.SetRoof(c, null); }
            var bound = CellRect.CenteredOn(c, 2);
            foreach (var pawn2 in from pawn in map.mapPawns.AllPawnsSpawned where bound.Contains(pawn.Position) select pawn) { TaleRecorder.RecordTale(TaleDefOf.CollapseDodged, pawn2); }
        }

        private static int AdjacentUnroofedTiles(IntVec3 c, Map map)
        {
            var adjacent = 0;
            for (var side = 0; side < 3; side++)
            {
                RoofDef roof;
                switch (side)
                {
                    case 0:
                        roof = map.roofGrid.RoofAt(c.x, c.z - 1);
                        break;
                    case 1:
                        roof = map.roofGrid.RoofAt(c.x + 1, c.z);
                        break;
                    case 2:
                        roof = map.roofGrid.RoofAt(c.x, c.z + 1);
                        break;
                    case 3:
                        roof = map.roofGrid.RoofAt(c.x - 1, c.z);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (roof == null) { adjacent++; }
            }

            return adjacent;
        }
    }
}
