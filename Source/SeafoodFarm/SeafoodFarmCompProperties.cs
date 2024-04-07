using System.Collections.Generic;
using Verse;

namespace SeafoodFarm;

public class SeafoodFarmCompProperties : CompProperties
{
    public readonly List<string> affectedByDefName = [];
    public readonly int affectRange = 5;
    public readonly List<int> spawnAmounts = [];
    public readonly int spawnDays = 1;

    public readonly List<ThingDef> spawningThingDefs = [];

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