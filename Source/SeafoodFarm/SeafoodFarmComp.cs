using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace SeafoodFarm;

internal class SeafoodFarmComp : ThingComp
{
    private int currentTicks;

    private SeafoodFarmCompProperties Props => (SeafoodFarmCompProperties)props;

    private int SpawnTime => Props.spawnDays * GenDate.TicksPerDay;

    public override void PostExposeData()
    {
        Scribe_Values.Look(ref currentTicks, "currentTicks");
    }

    public override void CompTickRare()
    {
        currentTicks += 250;
        if (currentTicks < SpawnTime)
        {
            return;
        }

        SpawnItems();
        currentTicks -= SpawnTime;
    }

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        if (!Prefs.DevMode)
        {
            yield break;
        }

        var command_Action = new Command_Action
        {
            defaultLabel = "Sfarm.spawnnow".Translate(),
            action = SpawnItems
        };
        yield return command_Action;
    }

    private void SpawnItems()
    {
        for (var index = 0; index < Props.spawningThingDefs.Count; index++)
        {
            var thingDef = Props.spawningThingDefs[index];
            var item = ThingMaker.MakeThing(thingDef);
            if (IsAffected() != null)
            {
                item.stackCount = (int)Math.Round(Props.spawnAmounts[index] * 1.15);
            }
            else
            {
                item.stackCount = Props.spawnAmounts[index];
            }

            GenPlace.TryPlaceThing(item, parent.Position, parent.Map, ThingPlaceMode.Near);
        }
    }

    private string IsAffected()
    {
        if (!Props.affectedByDefName.Any())
        {
            return null;
        }

        foreach (var c in GenAdj.CellsOccupiedBy(parent.Position, parent.Rotation, parent.def.Size))
        {
            var affectees = GenRadial.RadialDistinctThingsAround(c, parent.Map, Props.affectRange, true)
                .Where(thing => Props.affectedByDefName.Contains(thing.def.defName));

            if (affectees.Any())
            {
                return affectees.First().LabelCap;
            }
        }

        return null;
    }


    public override string CompInspectStringExtra()
    {
        var returnString =
            "Sfarm.nextspawn".Translate((SpawnTime - currentTicks).ToStringTicksToPeriod());
        var affectedBy = IsAffected();
        if (affectedBy != null)
        {
            returnString += "Sfarm.affected".Translate(affectedBy);
        }

        return returnString;
    }
}