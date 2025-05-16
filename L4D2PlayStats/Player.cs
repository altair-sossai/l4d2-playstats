using L4D2PlayStats.Enums;
using L4D2PlayStats.Extensions;
using L4D2PlayStats.Steam;

namespace L4D2PlayStats;

public class Player : SteamUser
{
    public Player()
    {
    }

    public Player(string line)
        : this(line.Queue())
    {
    }

    private Player(Queue<string> queue)
    {
        Index = queue.DequeueAsInt();
        Client = queue.DequeueAsInt();
        SteamId = queue.Dequeue();
        ShotsShotgun = queue.DequeueAsInt();
        ShotsSmg = queue.DequeueAsInt();
        ShotsSniper = queue.DequeueAsInt();
        ShotsPistol = queue.DequeueAsInt();
        HitsShotgun = queue.DequeueAsInt();
        HitsSmg = queue.DequeueAsInt();
        HitsSniper = queue.DequeueAsInt();
        HitsPistol = queue.DequeueAsInt();
        HeadshotsSmg = queue.DequeueAsInt();
        HeadshotsSniper = queue.DequeueAsInt();
        HeadshotsPistol = queue.DequeueAsInt();
        HeadshotsSiSmg = queue.DequeueAsInt();
        HeadshotsSiSniper = queue.DequeueAsInt();
        HeadshotsSiPistol = queue.DequeueAsInt();
        HitsSiShotgun = queue.DequeueAsInt();
        HitsSiSmg = queue.DequeueAsInt();
        HitsSiSniper = queue.DequeueAsInt();
        HitsSiPistol = queue.DequeueAsInt();
        HitsTankShotgun = queue.DequeueAsInt();
        HitsTankSmg = queue.DequeueAsInt();
        HitsTankSniper = queue.DequeueAsInt();
        HitsTankPistol = queue.DequeueAsInt();
        Common = queue.DequeueAsInt();
        CommonTankUp = queue.DequeueAsInt();
        SiKilled = queue.DequeueAsInt();
        SiKilledTankUp = queue.DequeueAsInt();
        SiDamage = queue.DequeueAsInt();
        SiDamageTankUp = queue.DequeueAsInt();
        Incaps = queue.DequeueAsInt();
        Died = queue.DequeueAsInt();
        Skeets = queue.DequeueAsInt();
        SkeetsHurt = queue.DequeueAsInt();
        SkeetsMelee = queue.DequeueAsInt();
        Levels = queue.DequeueAsInt();
        LevelsHurt = queue.DequeueAsInt();
        Pops = queue.DequeueAsInt();
        Crowns = queue.DequeueAsInt();
        CrownsHurt = queue.DequeueAsInt();
        Shoves = queue.DequeueAsInt();
        DeadStops = queue.DequeueAsInt();
        TongueCuts = queue.DequeueAsInt();
        SelfClears = queue.DequeueAsInt();
        FallDamage = queue.DequeueAsInt();
        DmgTaken = queue.DequeueAsInt();
        FfGiven = queue.DequeueAsInt();
        FfTaken = queue.DequeueAsInt();
        FfHits = queue.DequeueAsInt();
        TankDamage = queue.DequeueAsInt();
        WitchDamage = queue.DequeueAsInt();
        MeleesOnTank = queue.DequeueAsInt();
        RockSkeets = queue.DequeueAsInt();
        RockEats = queue.DequeueAsInt();
        FfGivenPellet = queue.DequeueAsInt();
        FfGivenBullet = queue.DequeueAsInt();
        FfGivenSniper = queue.DequeueAsInt();
        FfGivenMelee = queue.DequeueAsInt();
        FfGivenFire = queue.DequeueAsInt();
        FfGivenIncap = queue.DequeueAsInt();
        FfGivenOther = queue.DequeueAsInt();
        FfGivenSelf = queue.DequeueAsInt();
        FfTakenPellet = queue.DequeueAsInt();
        FfTakenBullet = queue.DequeueAsInt();
        FfTakenSniper = queue.DequeueAsInt();
        FfTakenMelee = queue.DequeueAsInt();
        FfTakenFire = queue.DequeueAsInt();
        FfTakenIncap = queue.DequeueAsInt();
        FfTakenOther = queue.DequeueAsInt();
        FfGivenTotal = queue.DequeueAsInt();
        FfTakenTotal = queue.DequeueAsInt();
        Clears = queue.DequeueAsInt();
        AvgClearTime = queue.DequeueAsInt();
        TimeStartPresent = queue.DequeueAsDateTime();
        TimeStopPresent = queue.DequeueAsDateTime();
        TimeStartAlive = queue.DequeueAsDateTime();
        TimeStopAlive = queue.DequeueAsDateTime();
        TimeStartUpright = queue.DequeueAsDateTime();
        TimeStopUpright = queue.DequeueAsDateTime();
    }

    public int Index { get; set; }
    public int Client { get; set; }
    public string? PlayerName { get; set; }
    public int ShotsShotgun { get; set; }
    public int ShotsSmg { get; set; }
    public int ShotsSniper { get; set; }
    public int ShotsPistol { get; set; }
    public int HitsShotgun { get; set; }
    public int HitsSmg { get; set; }
    public int HitsSniper { get; set; }
    public int HitsPistol { get; set; }
    public int HeadshotsSmg { get; set; }
    public int HeadshotsSniper { get; set; }
    public int HeadshotsPistol { get; set; }
    public int HeadshotsSiSmg { get; set; }
    public int HeadshotsSiSniper { get; set; }
    public int HeadshotsSiPistol { get; set; }
    public int HitsSiShotgun { get; set; }
    public int HitsSiSmg { get; set; }
    public int HitsSiSniper { get; set; }
    public int HitsSiPistol { get; set; }
    public int HitsTankShotgun { get; set; }
    public int HitsTankSmg { get; set; }
    public int HitsTankSniper { get; set; }
    public int HitsTankPistol { get; set; }
    public int Common { get; set; }
    public int CommonTankUp { get; set; }
    public int SiKilled { get; set; }
    public int SiKilledTankUp { get; set; }
    public int SiDamage { get; set; }
    public int SiDamageTankUp { get; set; }
    public int Incaps { get; set; }
    public int Died { get; set; }
    public int Skeets { get; set; }
    public int SkeetsHurt { get; set; }
    public int SkeetsMelee { get; set; }
    public int Levels { get; set; }
    public int LevelsHurt { get; set; }
    public int Pops { get; set; }
    public int Crowns { get; set; }
    public int CrownsHurt { get; set; }
    public int Shoves { get; set; }
    public int DeadStops { get; set; }
    public int TongueCuts { get; set; }
    public int SelfClears { get; set; }
    public int FallDamage { get; set; }
    public int DmgTaken { get; set; }
    public int FfGiven { get; set; }
    public int FfTaken { get; set; }
    public int FfHits { get; set; }
    public int TankDamage { get; set; }
    public int WitchDamage { get; set; }
    public int MeleesOnTank { get; set; }
    public int RockSkeets { get; set; }
    public int RockEats { get; set; }
    public int FfGivenPellet { get; set; }
    public int FfGivenBullet { get; set; }
    public int FfGivenSniper { get; set; }
    public int FfGivenMelee { get; set; }
    public int FfGivenFire { get; set; }
    public int FfGivenIncap { get; set; }
    public int FfGivenOther { get; set; }
    public int FfGivenSelf { get; set; }
    public int FfTakenPellet { get; set; }
    public int FfTakenBullet { get; set; }
    public int FfTakenSniper { get; set; }
    public int FfTakenMelee { get; set; }
    public int FfTakenFire { get; set; }
    public int FfTakenIncap { get; set; }
    public int FfTakenOther { get; set; }
    public int FfGivenTotal { get; set; }
    public int FfTakenTotal { get; set; }
    public int Clears { get; set; }
    public int AvgClearTime { get; set; }
    public DateTime? TimeStartPresent { get; set; }
    public DateTime? TimeStopPresent { get; set; }
    public TimeSpan? TimePresentElapsed => TimeStartPresent == null || TimeStopPresent == null ? null : TimeStopPresent - TimeStartPresent;
    public DateTime? TimeStartAlive { get; set; }
    public DateTime? TimeStopAlive { get; set; }
    public TimeSpan? TimeAliveElapsed => TimeStartAlive == null || TimeStopAlive == null ? null : TimeStopAlive - TimeStartAlive;
    public DateTime? TimeStartUpright { get; set; }
    public DateTime? TimeStopUpright { get; set; }
    public TimeSpan? TimeUprightElapsed => TimeStartUpright == null || TimeStopUpright == null ? null : TimeStopUpright - TimeStartUpright;

    public long this[PlayerStats playerStats]
    {
        get
        {
            return playerStats switch
            {
                PlayerStats.ShotsShotgun => ShotsShotgun,
                PlayerStats.ShotsSmg => ShotsSmg,
                PlayerStats.ShotsSniper => ShotsSniper,
                PlayerStats.ShotsPistol => ShotsPistol,
                PlayerStats.HitsShotgun => HitsShotgun,
                PlayerStats.HitsSmg => HitsSmg,
                PlayerStats.HitsSniper => HitsSniper,
                PlayerStats.HitsPistol => HitsPistol,
                PlayerStats.HeadshotsSmg => HeadshotsSmg,
                PlayerStats.HeadshotsSniper => HeadshotsSniper,
                PlayerStats.HeadshotsPistol => HeadshotsPistol,
                PlayerStats.HeadshotsSiSmg => HeadshotsSiSmg,
                PlayerStats.HeadshotsSiSniper => HeadshotsSiSniper,
                PlayerStats.HeadshotsSiPistol => HeadshotsSiPistol,
                PlayerStats.HitsSiShotgun => HitsSiShotgun,
                PlayerStats.HitsSiSmg => HitsSiSmg,
                PlayerStats.HitsSiSniper => HitsSiSniper,
                PlayerStats.HitsSiPistol => HitsSiPistol,
                PlayerStats.HitsTankShotgun => HitsTankShotgun,
                PlayerStats.HitsTankSmg => HitsTankSmg,
                PlayerStats.HitsTankSniper => HitsTankSniper,
                PlayerStats.HitsTankPistol => HitsTankPistol,
                PlayerStats.Common => Common,
                PlayerStats.CommonTankUp => CommonTankUp,
                PlayerStats.SiKilled => SiKilled,
                PlayerStats.SiKilledTankUp => SiKilledTankUp,
                PlayerStats.SiDamage => SiDamage,
                PlayerStats.SiDamageTankUp => SiDamageTankUp,
                PlayerStats.Incaps => Incaps,
                PlayerStats.Died => Died,
                PlayerStats.Skeets => Skeets,
                PlayerStats.SkeetsHurt => SkeetsHurt,
                PlayerStats.SkeetsMelee => SkeetsMelee,
                PlayerStats.Levels => Levels,
                PlayerStats.LevelsHurt => LevelsHurt,
                PlayerStats.Pops => Pops,
                PlayerStats.Crowns => Crowns,
                PlayerStats.CrownsHurt => CrownsHurt,
                PlayerStats.Shoves => Shoves,
                PlayerStats.DeadStops => DeadStops,
                PlayerStats.TongueCuts => TongueCuts,
                PlayerStats.SelfClears => SelfClears,
                PlayerStats.FallDamage => FallDamage,
                PlayerStats.DmgTaken => DmgTaken,
                PlayerStats.FfGiven => FfGiven,
                PlayerStats.FfTaken => FfTaken,
                PlayerStats.FfHits => FfHits,
                PlayerStats.TankDamage => TankDamage,
                PlayerStats.WitchDamage => WitchDamage,
                PlayerStats.MeleesOnTank => MeleesOnTank,
                PlayerStats.RockSkeets => RockSkeets,
                PlayerStats.RockEats => RockEats,
                PlayerStats.FfGivenPellet => FfGivenPellet,
                PlayerStats.FfGivenBullet => FfGivenBullet,
                PlayerStats.FfGivenSniper => FfGivenSniper,
                PlayerStats.FfGivenMelee => FfGivenMelee,
                PlayerStats.FfGivenFire => FfGivenFire,
                PlayerStats.FfGivenIncap => FfGivenIncap,
                PlayerStats.FfGivenOther => FfGivenOther,
                PlayerStats.FfGivenSelf => FfGivenSelf,
                PlayerStats.FfTakenPellet => FfTakenPellet,
                PlayerStats.FfTakenBullet => FfTakenBullet,
                PlayerStats.FfTakenSniper => FfTakenSniper,
                PlayerStats.FfTakenMelee => FfTakenMelee,
                PlayerStats.FfTakenFire => FfTakenFire,
                PlayerStats.FfTakenIncap => FfTakenIncap,
                PlayerStats.FfTakenOther => FfTakenOther,
                PlayerStats.FfGivenTotal => FfGivenTotal,
                PlayerStats.FfTakenTotal => FfTakenTotal,
                PlayerStats.Clears => Clears,
                PlayerStats.AvgClearTime => AvgClearTime,
                PlayerStats.TimeStartPresent => TimeStartPresent.ToUnixTimeSeconds(),
                PlayerStats.TimeStopPresent => TimeStopPresent.ToUnixTimeSeconds(),
                PlayerStats.TimeStartAlive => TimeStartAlive.ToUnixTimeSeconds(),
                PlayerStats.TimeStopAlive => TimeStopAlive.ToUnixTimeSeconds(),
                PlayerStats.TimeStartUpright => TimeStartUpright.ToUnixTimeSeconds(),
                PlayerStats.TimeStopUpright => TimeStopUpright.ToUnixTimeSeconds(),
                _ => throw new ArgumentOutOfRangeException(nameof(playerStats), playerStats, null)
            };
        }
    }
}