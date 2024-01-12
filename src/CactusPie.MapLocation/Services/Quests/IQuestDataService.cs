using System.Collections.Generic;
using CactusPie.MapLocation.Common.Requests.Data;
using EFT.Interactive;

namespace CactusPie.MapLocation.Services.Quests
{
    public interface IQuestDataService
    {
        IReadOnlyList<CustomQuestData> QuestMarkers { get; }

        void ReloadQuestData(TriggerWithId[] allTriggers);
    }
}