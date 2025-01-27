﻿namespace CactusPie.MapLocation.Common.Requests.Data
{
    public sealed class CustomBotData
    {
        public int BotId { get; set; }

        public BotType BotType { get; set; }

        public float XPosition { get; set; }

        public float YPosition { get; set; }

        public float ZPosition { get; set; }
    }
}