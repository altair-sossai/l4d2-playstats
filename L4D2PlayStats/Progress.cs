using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class Progress
{
    public Progress()
    {
    }

    public Progress(string line)
        : this(line.Queue())
    {
    }

    private Progress(Queue<string> queue)
    {
        Round = queue.DequeueAsInt();
        Team = queue.DequeueAsChar();
        Survived = queue.DequeueAsInt();
        MaxCompletionScore = queue.DequeueAsInt();
        MaxFlowDist = queue.DequeueAsDecimal();

        while (queue.Count >= 2)
            Flows.Add(new Flow(queue));
    }

    public int Round { get; set; }
    public char Team { get; set; }
    public int Survived { get; set; }
    public int MaxCompletionScore { get; set; }
    public decimal MaxFlowDist { get; set; }
    public List<Flow> Flows { get; set; } = [];

    public override string ToString()
    {
        return $"{Round};{Team};{Survived};{MaxCompletionScore};{MaxFlowDist};{string.Join(";", Flows)};";
    }

    public class Flow
    {
        public Flow()
        {
        }

        public Flow(Queue<string> queue)
        {
            FarFlowDist = queue.DequeueAsDecimal();
            CurFlowDist = queue.DequeueAsDecimal();
        }

        public decimal FarFlowDist { get; set; }
        public decimal CurFlowDist { get; set; }

        public override string ToString()
        {
            return $"{FarFlowDist};{CurFlowDist}";
        }
    }
}