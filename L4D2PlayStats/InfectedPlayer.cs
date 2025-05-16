using L4D2PlayStats.Enums;
using L4D2PlayStats.Extensions;
using L4D2PlayStats.Steam;

namespace L4D2PlayStats;

public class InfectedPlayer : SteamUser
{
    public InfectedPlayer()
    {
    }

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

    public int Index { get; set; }
    public int Client { get; set; }
    public string? PlayerName { get; set; }
    public int DmgTotal { get; set; }
    public int DmgUpright { get; set; }
    public int DmgTank { get; set; }
    public int DmgTankIncap { get; set; }
    public int DmgScratch { get; set; }
    public int DmgSpit { get; set; }
    public int DmgBoom { get; set; }
    public int DmgTankUp { get; set; }
    public int HunterDPs { get; set; }
    public int HunterDpDmg { get; set; }
    public int JockeyDPs { get; set; }
    public int DeathCharges { get; set; }
    public int Booms { get; set; }
    public int Ledged { get; set; }
    public int Common { get; set; }
    public int Spawns { get; set; }
    public int SpawnSmoker { get; set; }
    public int SpawnBoomer { get; set; }
    public int SpawnHunter { get; set; }
    public int SpawnCharger { get; set; }
    public int SpawnSpitter { get; set; }
    public int SpawnJockey { get; set; }
    public int TankPasses { get; set; }
    public DateTime? TimeStartPresent { get; set; }
    public DateTime? TimeStopPresent { get; set; }
    public TimeSpan? TimePresentElapsed => TimeStartPresent == null || TimeStopPresent == null ? null : TimeStopPresent - TimeStartPresent;

    public long this[InfectedStats infectedStats]
    {
        get
        {
            return infectedStats switch
            {
                InfectedStats.DmgTotal => DmgTotal,
                InfectedStats.DmgUpright => DmgUpright,
                InfectedStats.DmgTank => DmgTank,
                InfectedStats.DmgTankIncap => DmgTankIncap,
                InfectedStats.DmgScratch => DmgScratch,
                InfectedStats.DmgSpit => DmgSpit,
                InfectedStats.DmgBoom => DmgBoom,
                InfectedStats.DmgTankUp => DmgTankUp,
                InfectedStats.HunterDPs => HunterDPs,
                InfectedStats.HunterDpDmg => HunterDpDmg,
                InfectedStats.JockeyDPs => JockeyDPs,
                InfectedStats.DeathCharges => DeathCharges,
                InfectedStats.Booms => Booms,
                InfectedStats.Ledged => Ledged,
                InfectedStats.Common => Common,
                InfectedStats.Spawns => Spawns,
                InfectedStats.SpawnSmoker => SpawnSmoker,
                InfectedStats.SpawnBoomer => SpawnBoomer,
                InfectedStats.SpawnHunter => SpawnHunter,
                InfectedStats.SpawnCharger => SpawnCharger,
                InfectedStats.SpawnSpitter => SpawnSpitter,
                InfectedStats.SpawnJockey => SpawnJockey,
                InfectedStats.TankPasses => TankPasses,
                InfectedStats.TimeStartPresent => TimeStartPresent.ToUnixTimeSeconds(),
                InfectedStats.TimeStopPresent => TimeStopPresent.ToUnixTimeSeconds(),
                _ => throw new ArgumentOutOfRangeException(nameof(infectedStats), infectedStats, null)
            };
        }
    }
}