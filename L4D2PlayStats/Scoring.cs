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

	public class Team
	{
		public Team(Queue<string> queue)
		{
			Letter = queue.DequeueAsChar();
			FirstScoresSet = queue.DequeueAsInt();
			Score = queue.DequeueAsInt();
		}

		public char Letter { get; }
		public int FirstScoresSet { get; }
		public int Score { get; }
	}
}