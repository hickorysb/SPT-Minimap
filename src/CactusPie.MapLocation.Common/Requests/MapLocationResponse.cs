﻿using System;
using System.Collections.Generic;
using CactusPie.MapLocation.Common.Requests.Data;

namespace CactusPie.MapLocation.Common.Requests
{
    public sealed class MapLocationResponse
    {
        public List<CustomBotData> BotLocations { get; set; }

        public bool IsGameInProgress { get; set; }

        public string MapName { get; set; }

        public float XPosition { get; set; }

        public float XRotation { get; set; }

        public float YPosition { get; set; }

        public float YRotation { get; set; }

        public float ZPosition { get; set; }

        public DateTime? LastQuestChangeTime { get; set; }

        public AirdropData Airdrop { get; set; }
    }
}