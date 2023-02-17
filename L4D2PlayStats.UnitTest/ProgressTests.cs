using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class ProgressTests
{
	[TestMethod]
	public void GivenValidLineShouldBeAbleToExtractValues()
	{
		const string line = "0;A;0;400;11629.93;7333.72;9998.64;9998.64;7277.55;8428.84;8428.84;7926.63;9998.64;";

		var progress = new Progress(line);

		progress.Round.Should().Be(0);
		progress.Team.Should().Be('A');
		progress.Survived.Should().Be(0);
		progress.MaxCompletionScore.Should().Be(400);
		progress.MaxFlowDist.Should().Be(11629.93m);
		progress.Flows.Should().HaveCount(4);

		var flows = progress.Flows;

		flows[0].FarFlowDist.Should().Be(7333.72m);
		flows[0].CurFlowDist.Should().Be(9998.64m);

		flows[1].FarFlowDist.Should().Be(9998.64m);
		flows[1].CurFlowDist.Should().Be(7277.55m);

		flows[2].FarFlowDist.Should().Be(8428.84m);
		flows[2].CurFlowDist.Should().Be(8428.84m);

		flows[3].FarFlowDist.Should().Be(7926.63m);
		flows[3].CurFlowDist.Should().Be(9998.64m);
	}
}