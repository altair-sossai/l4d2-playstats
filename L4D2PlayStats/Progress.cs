using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class Progress
{
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

	public int Round { get; }
	public char Team { get; }
	public int Survived { get; }
	public int MaxCompletionScore { get; }
	public decimal MaxFlowDist { get; }
	public List<Flow> Flows { get; } = new();

	public class Flow
	{
		public Flow(Queue<string> queue)
		{
			FarFlowDist = queue.DequeueAsDecimal();
			CurFlowDist = queue.DequeueAsDecimal();
		}

		public decimal FarFlowDist { get; }
		public decimal CurFlowDist { get; }
	}
}