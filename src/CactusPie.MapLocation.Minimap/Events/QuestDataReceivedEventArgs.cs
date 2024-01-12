using System;
using System.Collections.Generic;
using CactusPie.MapLocation.Common.Requests.Data;

namespace CactusPie.MapLocation.Minimap.Events;

public class QuestDataReceivedEventArgs : EventArgs
{
    public QuestDataReceivedEventArgs(IReadOnlyList<CustomQuestData>? quests)
    {
        Quests = quests;
    }

    public IReadOnlyList<CustomQuestData>? Quests { get; set; }
}