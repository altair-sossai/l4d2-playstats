using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class Scoring
{
    public Scoring(string line)
        : this(line.Queue())
    {
    }

    private Scoring(Queue<string> queue)
    {
        TeamA = new Team(queue);
        TeamB = new Team(queue);
    }

    public Team? TeamA { get; }
    public Team? TeamB { get; }

    public class Team(Queue<string> queue)
    {
        public char Letter { get; } = queue.DequeueAsChar();
        public int FirstScoresSet { get; } = queue.DequeueAsInt();
        public int Score { get; } = queue.DequeueAsInt();
    }
}