namespace CactusPie.MapLocation.Common.Requests.Data
{
    public sealed class CustomQuestData
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public QuestLocation Location { get; set; }

        public string NameText { get; set; }

        public string Trader { get; set; }

        public string ZoneId { get; set; }
    }
}