using L4D2PlayStats.Enums;
using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class RoundHalf
{
    public RoundHalf(string line)
        : this(line.Queue())
    {
    }

    private RoundHalf(Queue<string> queue)
    {
        Round = queue.DequeueAsInt();
        Team = queue.DequeueAsChar();
        Restarts = queue.DequeueAsInt();
        PillsUsed = queue.DequeueAsInt();
        KitsUsed = queue.DequeueAsInt();
        DefibsUsed = queue.DequeueAsInt();
        Common = queue.DequeueAsInt();
        SiKilled = queue.DequeueAsInt();
        SiDamage = queue.DequeueAsInt();
        SiSpawned = queue.DequeueAsInt();
        WitchKilled = queue.DequeueAsInt();
        TankKilled = queue.DequeueAsInt();
        Incaps = queue.DequeueAsInt();
        Deaths = queue.DequeueAsInt();
        FfDamageTotal = queue.DequeueAsInt();
        StartTime = queue.DequeueAsDateTime();
        EndTime = queue.DequeueAsDateTime();
        StartTimePause = queue.DequeueAsDateTime();
        StopTimePause = queue.DequeueAsDateTime();
        StartTimeTank = queue.DequeueAsDateTime();
        StopTimeTank = queue.DequeueAsDateTime();
    }

    public int Round { get; }
    public char Team { get; }
    public int Restarts { get; }
    public int PillsUsed { get; }
    public int KitsUsed { get; }
    public int DefibsUsed { get; }
    public int Common { get; }
    public int SiKilled { get; }
    public int SiDamage { get; }
    public int SiSpawned { get; }
    public int WitchKilled { get; }
    public int TankKilled { get; }
    public int Incaps { get; }
    public int Deaths { get; }
    public int FfDamageTotal { get; }
    public DateTime? StartTime { get; }
    public DateTime? EndTime { get; }
    public TimeSpan? RoundElapsed => StartTime == null || EndTime == null ? null : EndTime - StartTime;
    public DateTime? StartTimePause { get; }
    public DateTime? StopTimePause { get; }
    public TimeSpan? PauseElapsed => StartTimePause == null || StopTimePause == null ? null : StopTimePause - StartTimePause;
    public DateTime? StartTimeTank { get; }
    public DateTime? StopTimeTank { get; }
    public TimeSpan? TankElapsed => StartTimeTank == null || StopTimeTank == null ? null : StopTimeTank - StartTimeTank;

    public long this[RoundStats roundStats]
    {
        get
        {
            return roundStats switch
            {
                RoundStats.Restarts => Restarts,
                RoundStats.PillsUsed => PillsUsed,
                RoundStats.KitsUsed => KitsUsed,
                RoundStats.DefibsUsed => DefibsUsed,
                RoundStats.Common => Common,
                RoundStats.SiKilled => SiKilled,
                RoundStats.SiDamage => SiDamage,
                RoundStats.SiSpawned => SiSpawned,
                RoundStats.WitchKilled => WitchKilled,
                RoundStats.TankKilled => TankKilled,
                RoundStats.Incaps => Incaps,
                RoundStats.Deaths => Deaths,
                RoundStats.FfDamageTotal => FfDamageTotal,
                RoundStats.StartTime => StartTime.ToUnixTimeSeconds(),
                RoundStats.EndTime => EndTime.ToUnixTimeSeconds(),
                RoundStats.StartTimePause => StartTimePause.ToUnixTimeSeconds(),
                RoundStats.StopTimePause => StopTimePause.ToUnixTimeSeconds(),
                RoundStats.StartTimeTank => StartTimeTank.ToUnixTimeSeconds(),
                RoundStats.StopTimeTank => StopTimeTank.ToUnixTimeSeconds(),
                _ => throw new ArgumentOutOfRangeException(nameof(roundStats), roundStats, null)
            };
        }
    }
}