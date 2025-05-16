using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class Scoring
{
    public Scoring()
    {
    }

    public Scoring(string line)
        : this(line.Queue())
    {
    }

    private Scoring(Queue<string> queue)
    {
        TeamA = new Team(queue);
        TeamB = new Team(queue);
    }

    public Team? TeamA { get; set; }
    public Team? TeamB { get; set; }
    public int? ScoreDiff => Math.Abs((TeamA?.Score ?? 0) - (TeamB?.Score ?? 0));
    public bool Draw => ScoreDiff == 0;
    public bool TeamAWon => TeamA?.Score > TeamB?.Score;
    public bool TeamBWon => TeamB?.Score > TeamA?.Score;

    public class Team
    {
        public Team()
        {
        }

        public Team(Queue<string> queue)
        {
            Letter = queue.DequeueAsChar();
            FirstScoresSet = queue.DequeueAsInt();
            Score = queue.DequeueAsInt();
        }

        public char Letter { get; set; }
        public int FirstScoresSet { get; set; }
        public int Score { get; set; }
    }
}