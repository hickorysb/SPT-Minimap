﻿using System;
using System.Collections.Generic;
using CactusPie.MapLocation.Common.Requests.Data;
using CactusPie.MapLocation.Minimap.Data;
using CactusPie.MapLocation.Minimap.Events;
using CactusPie.MapLocation.Minimap.MapHandling.Data;
using CactusPie.MapLocation.Minimap.MapHandling.Interfaces;

namespace CactusPie.MapLocation.Minimap.Services.Interfaces;

public interface ICurrentMapData
{
    int PositionRefreshRate { get; set; }

    bool AutomaticallySwitchLevels { get; set; }

    string? CurrentMapCreationData { get; }

    bool IsGameInProgress { get; set; }

    MapPositionData? LastReceivedPosition { get; set; }

    IReadOnlyList<CustomQuestData>? Quests { get; set; }

    BoundData? SelectedBound { get; set; }

    IMap? SelectedMap { get; set; }

    event EventHandler<EventArgs>? MapSelectionChanged;

    event EventHandler<EventArgs>? LastReceivedPositionChanged;

    event EventHandler<EventArgs>? SelectedBoundChanged;

    event EventHandler<EventArgs>? BoundDataUpdated;

    event EventHandler<QuestDataReceivedEventArgs>? QuestsChanged;

    event EventHandler<IsGameInProgressChangedEventArgs>? GameStateChanged;

    event EventHandler<BeforeSelectedBoundChangedEventArgs>? BeforeSelectedBoundChanged;

    void OnBoundDataUpdated(object sender);

    void SetCurrentMapCreationDataSource(Func<string>? getMapCreationData);
}