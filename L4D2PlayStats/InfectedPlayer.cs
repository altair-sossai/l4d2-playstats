using L4D2PlayStats.Extensions;
using L4D2PlayStats.Steam;

namespace L4D2PlayStats;

public class InfectedPlayer : SteamUser
{
    public InfectedPlayer(string line)
        : this(line.Queue())
    {
    }

    private InfectedPlayer(Queue<string> queue)
    {
        Index = queue.DequeueAsInt();
        Client = queue.DequeueAsInt();
        SteamId = queue.Dequeue();
        DmgTotal = queue.DequeueAsInt();
        DmgUpright = queue.DequeueAsInt();
        DmgTank = queue.DequeueAsInt();
        DmgTankIncap = queue.DequeueAsInt();
        DmgScratch = queue.DequeueAsInt();
        DmgSpit = queue.DequeueAsInt();
        DmgBoom = queue.DequeueAsInt();
        DmgTankUp = queue.DequeueAsInt();
        HunterDPs = queue.DequeueAsInt();
        HunterDpDmg = queue.DequeueAsInt();
        JockeyDPs = queue.DequeueAsInt();
        DeathCharges = queue.DequeueAsInt();
        Booms = queue.DequeueAsInt();
        Ledged = queue.DequeueAsInt();
        Common = queue.DequeueAsInt();
        Spawns = queue.DequeueAsInt();
        SpawnSmoker = queue.DequeueAsInt();
        SpawnBoomer = queue.DequeueAsInt();
        SpawnHunter = queue.DequeueAsInt();
        SpawnCharger = queue.DequeueAsInt();
        SpawnSpitter = queue.DequeueAsInt();
        SpawnJockey = queue.DequeueAsInt();
        TankPasses = queue.DequeueAsInt();
        TimeStartPresent = queue.DequeueAsDateTime();
        TimeStopPresent = queue.DequeueAsDateTime();
    }

    public int Index { get; }
    public int Client { get; }
    public string? PlayerName { get; internal set; }
    public int DmgTotal { get; }
    public int DmgUpright { get; }
    public int DmgTank { get; }
    public int DmgTankIncap { get; }
    public int DmgScratch { get; }
    public int DmgSpit { get; }
    public int DmgBoom { get; }
    public int DmgTankUp { get; }
    public int HunterDPs { get; }
    public int HunterDpDmg { get; }
    public int JockeyDPs { get; }
    public int DeathCharges { get; }
    public int Booms { get; }
    public int Ledged { get; }
    public int Common { get; }
    public int Spawns { get; }
    public int SpawnSmoker { get; }
    public int SpawnBoomer { get; }
    public int SpawnHunter { get; }
    public int SpawnCharger { get; }
    public int SpawnSpitter { get; }
    public int SpawnJockey { get; }
    public int TankPasses { get; }
    public DateTime? TimeStartPresent { get; }
    public DateTime? TimeStopPresent { get; }
}