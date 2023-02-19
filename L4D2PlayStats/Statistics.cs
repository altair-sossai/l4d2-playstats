using System.Text.RegularExpressions;

namespace L4D2PlayStats;

public class Statistics
{
    public Statistics(string content)
    {
        var lines = content.Split('\n').Select(l => l.Trim());
        var queue = new Queue<string>(lines);

        while (queue.Any())
        {
            var line = queue.Dequeue();

            if (string.IsNullOrEmpty(line))
                continue;

            if (Regex.IsMatch(line, @"\[Gameround:\d+\]"))
                GameRound = new GameRound(queue.Dequeue());

            else if (Regex.IsMatch(line, @"\[RoundHalf:\d\]"))
                AddRoundHalf(new RoundHalf(queue.Dequeue()));

            else if (Regex.IsMatch(line, @"\[Progress:\w\]"))
                AddProgress(new Progress(queue.Dequeue()));

            else if (Regex.IsMatch(line, @"\[Players:\w\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    AddPlayer(new Player(queue.Dequeue()));
            }

            else if (Regex.IsMatch(line, @"\[InfectedPlayers:\w\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    AddInfectedPlayer(new InfectedPlayer(queue.Dequeue()));
            }

            else if (Regex.IsMatch(line, @"\[Scoring:\]"))
                Scoring = new Scoring(queue.Dequeue());

            else if (Regex.IsMatch(line, @"\[PlayerNames:\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    PlayerNames.Add(new PlayerName(queue.Dequeue()));
            }
        }

        UpdatePlayerName();
    }

    public GameRound? GameRound { get; }
    public List<Half> Halves { get; } = new();
    public Scoring? Scoring { get; }
    public List<PlayerName> PlayerNames { get; } = new();
    public List<PlayerName> TeamA { get; } = new();
    public List<PlayerName> TeamB { get; } = new();

    public static bool TryParse(string content, out Statistics? statistics)
    {
        try
        {
            statistics = new Statistics(content);
            return true;
        }
        catch (Exception)
        {
            statistics = null;
            return false;
        }
    }

    private Half AddHalf()
    {
        var half = new Half();

        Halves.Add(half);

        return half;
    }

    private void AddRoundHalf(RoundHalf roundHalf)
    {
        var half = Halves.FirstOrDefault(f => f.RoundHalf == null) ?? AddHalf();

        half.RoundHalf = roundHalf;
    }

    private void AddProgress(Progress progress)
    {
        var half = Halves.FirstOrDefault(f => f.Progress == null) ?? AddHalf();

        half.Progress = progress;
    }

    private void AddPlayer(Player player)
    {
        var half = Halves.Last(f => f.RoundHalf != null);

        half.Players.Add(player);
    }

    private void AddInfectedPlayer(InfectedPlayer infectedPlayer)
    {
        var half = Halves.Last(f => f.RoundHalf != null);

        half.InfectedPlayers.Add(infectedPlayer);
    }

    private void UpdatePlayerName()
    {
        var names = PlayerNames
            .Where(p => !string.IsNullOrEmpty(p.CommunityId))
            .ToDictionary(k => k.CommunityId!, v => v);

        foreach (var half in Halves)
        {
            var team = half.Progress?.Team == 'A' ? TeamA : TeamB;

            foreach (var player in half.Players.Where(player => !string.IsNullOrEmpty(player.CommunityId) && names.ContainsKey(player.CommunityId)))
            {
                var playerName = names[player.CommunityId!];

                player.PlayerName = playerName.Name;
                team.Add(playerName);
            }

            foreach (var infectedPlayer in half.InfectedPlayers.Where(player => !string.IsNullOrEmpty(player.CommunityId) && names.ContainsKey(player.CommunityId)))
                infectedPlayer.PlayerName = names[infectedPlayer.CommunityId!].Name;
        }
    }

    public class Half
    {
        public RoundHalf? RoundHalf { get; internal set; }
        public Progress? Progress { get; internal set; }
        public List<Player> Players { get; } = new();
        public List<InfectedPlayer> InfectedPlayers { get; } = new();
    }
}