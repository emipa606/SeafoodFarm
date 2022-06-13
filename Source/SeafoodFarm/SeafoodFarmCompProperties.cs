using System.Collections.Generic;
using Verse;

namespace SeafoodFarm;

public class SeafoodFarmCompProperties : CompProperties
{
    public List<string> affectedByDefName = new List<string>();
    public int affectRange = 5;
    public List<int> spawnAmounts = new List<int>();
    public int spawnDays = 1;

    public List<ThingDef> spawningThingDefs = new List<ThingDef>();

    public SeafoodFarmCompProperties()
    {
        compClass = typeof(SeafoodFarmComp);
    }

    public override IEnumerable<string> ConfigErrors(ThingDef parentDef)
    {
        foreach (var configError in base.ConfigErrors(parentDef))
        {
            yield return configError;
        }

        if (spawningThingDefs.Count != spawnAmounts.Count)
        {
            yield return "Sfarm.wrongconfig".Translate(parentDef.defName, spawningThingDefs.Count, spawnAmounts.Count);
        }
    }
}