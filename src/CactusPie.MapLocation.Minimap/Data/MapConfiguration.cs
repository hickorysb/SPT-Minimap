namespace CactusPie.MapLocation.Minimap.Data;

public class MapConfiguration
{
    public string? GameIpAddress { get; init; }

    public int GamePort { get; init; }

    public string? Theme { get; init; }
    
    public bool? ShowPlayers { get; init; }
    
    public bool? ShowDeadPlayers { get; init; }
}