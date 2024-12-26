using PotionCraft.ObjectBased.WateringPot;
using PotionCraft.ScriptableObjects.BuildableInventoryItem;
using PotionCraft.ScriptableObjects.BuildZone;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GrowAnywhere
{
    class Functions
    {
        public static List<BuildZone> CreateBuildZoneList()
        {
            List<BuildZone> allAreas = new();
            List<string> areas = new List<string> { "Quartz 1", "Quartz 2", "Quartz 3", "Grass", "Cave", "Tree Trunk FG", "Tree Trunk BG", "Water", "Water", "Near Roots" };
            foreach (var ar in areas)
            {
                if (!allAreas.Contains(BuildZone.GetByName(ar)))
                {
                    allAreas.Add(BuildZone.GetByName(ar));
                }
            }
            return allAreas;
        }

        public static void AddZonesToSeeds()
        {
            List<BuildZone> allAreas = CreateBuildZoneList();
            List<BuildableInventoryItem> seeds = GetSeeds();

            foreach(var seed in seeds)
            {
                seed.allowedZones.zonesList = allAreas;
            }
        }

        public static List<BuildableInventoryItem> GetSeeds()
        {
            Dictionary<BuildableInventoryItemType, List<BuildableInventoryItem>> allBuildables = BuildableInventoryItem.allBuildableItems;
            return allBuildables[BuildableInventoryItemType.Seed];
        }

        public static void AllowGrottoWatering()
        {
            List<WateringPotItem> pots = Resources.FindObjectsOfTypeAll<WateringPotItem>().ToList();
            foreach (var pot in pots)
            {
                pot.Settings.dropSpawnRooms.Add(PotionCraft.ObjectBased.RoomIndex.Grotto);
            }
        }
    }
}
