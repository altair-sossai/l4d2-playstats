using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class Player
{
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

    public int Index { get; }
    public int Client { get; }
    public string? SteamId { get; }
    public int ShotsShotgun { get; }
    public int ShotsSmg { get; }
    public int ShotsSniper { get; }
    public int ShotsPistol { get; }
    public int HitsShotgun { get; }
    public int HitsSmg { get; }
    public int HitsSniper { get; }
    public int HitsPistol { get; }
    public int HeadshotsSmg { get; }
    public int HeadshotsSniper { get; }
    public int HeadshotsPistol { get; }
    public int HeadshotsSiSmg { get; }
    public int HeadshotsSiSniper { get; }
    public int HeadshotsSiPistol { get; }
    public int HitsSiShotgun { get; }
    public int HitsSiSmg { get; }
    public int HitsSiSniper { get; }
    public int HitsSiPistol { get; }
    public int HitsTankShotgun { get; }
    public int HitsTankSmg { get; }
    public int HitsTankSniper { get; }
    public int HitsTankPistol { get; }
    public int Common { get; }
    public int CommonTankUp { get; }
    public int SiKilled { get; }
    public int SiKilledTankUp { get; }
    public int SiDamage { get; }
    public int SiDamageTankUp { get; }
    public int Incaps { get; }
    public int Died { get; }
    public int Skeets { get; }
    public int SkeetsHurt { get; }
    public int SkeetsMelee { get; }
    public int Levels { get; }
    public int LevelsHurt { get; }
    public int Pops { get; }
    public int Crowns { get; }
    public int CrownsHurt { get; }
    public int Shoves { get; }
    public int DeadStops { get; }
    public int TongueCuts { get; }
    public int SelfClears { get; }
    public int FallDamage { get; }
    public int DmgTaken { get; }
    public int FfGiven { get; }
    public int FfTaken { get; }
    public int FfHits { get; }
    public int TankDamage { get; }
    public int WitchDamage { get; }
    public int MeleesOnTank { get; }
    public int RockSkeets { get; }
    public int RockEats { get; }
    public int FfGivenPellet { get; }
    public int FfGivenBullet { get; }
    public int FfGivenSniper { get; }
    public int FfGivenMelee { get; }
    public int FfGivenFire { get; }
    public int FfGivenIncap { get; }
    public int FfGivenOther { get; }
    public int FfGivenSelf { get; }
    public int FfTakenPellet { get; }
    public int FfTakenBullet { get; }
    public int FfTakenSniper { get; }
    public int FfTakenMelee { get; }
    public int FfTakenFire { get; }
    public int FfTakenIncap { get; }
    public int FfTakenOther { get; }
    public int FfGivenTotal { get; }
    public int FfTakenTotal { get; }
    public int Clears { get; }
    public int AvgClearTime { get; }
    public DateTime TimeStartPresent { get; }
    public DateTime TimeStopPresent { get; }
    public DateTime TimeStartAlive { get; }
    public DateTime TimeStopAlive { get; }
    public DateTime TimeStartUpright { get; }
    public DateTime TimeStopUpright { get; }
}