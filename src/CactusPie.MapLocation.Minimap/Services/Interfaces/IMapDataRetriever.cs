﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CactusPie.MapLocation.Common.Requests.Data;

namespace CactusPie.MapLocation.Minimap.Services.Interfaces;

public interface IMapDataRetriever : IDisposable
{
    void StartReceivingData();

    void StopReceivingData();

    Task<IReadOnlyList<CustomQuestData>?> GetQuestData(CancellationToken cancellationToken);
}