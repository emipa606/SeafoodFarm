using Verse;

namespace SeafoodFarm;

internal class PlaceWorker_OnOcean : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        foreach (var c in GenAdj.CellsOccupiedBy(loc, rot, checkingDef.Size))
        {
            var terrain = map.terrainGrid.TerrainAt(c);
            if (terrain.IsWater && terrain.defName.ToLower().Contains("ocean"))
            {
                continue;
            }

            return new AcceptanceReport("Sfarm.placeonocean".Translate(terrain.label));
        }

        return true;
    }
}