using System;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Collapser
{
    [HarmonyPatch(typeof(RoofCollapserImmediate), "DropRoofInCellPhaseTwo")]
    internal static class Patch
    {
        private static bool Prefix(IntVec3 c, Map map)
        {
            var roofDef = map.roofGrid.RoofAt(c);
            if (roofDef == null) { return false; }

            if (roofDef.filthLeaving != null) { FilthMaker.TryMakeFilth(c, map, roofDef.filthLeaving); }

            if (roofDef.VanishOnCollapse) { map.roofGrid.SetRoof(c, null); }
            else if (AdjacentUnroofedTiles(c, map) > 0) { map.roofGrid.SetRoof(c, null); }

            var bound = CellRect.CenteredOn(c, 2);
            foreach (var pawn2 in map.mapPawns.AllPawnsSpawned.Where(pawn => bound.Contains(pawn.Position))) { TaleRecorder.RecordTale(TaleDefOf.CollapseDodged, pawn2); }

            return false;
        }

        private static int AdjacentUnroofedTiles(IntVec3 c, Map map)
        {
            var adjacent = 0;
            for (var side = 0; side < 4; side++)
            {
                int cell;
                switch (side)
                {
                    case 0:
                        cell = map.cellIndices.CellToIndex(c.x, c.z - 1);
                        break;
                    case 1:
                        cell = map.cellIndices.CellToIndex(c.x + 1, c.z);
                        break;
                    case 2:
                        cell = map.cellIndices.CellToIndex(c.x, c.z + 1);
                        break;
                    case 3:
                        cell = map.cellIndices.CellToIndex(c.x - 1, c.z);
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }

                if ((cell < 0) || (cell >= map.cellIndices.NumGridCells)) { continue; }
                if (map.roofGrid.RoofAt(cell) == null) { adjacent++; }
            }

            return adjacent;
        }
    }
}
