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

        Assert.AreEqual(0, progress.Round);
        Assert.AreEqual('A', progress.Team);
        Assert.AreEqual(0, progress.Survived);
        Assert.AreEqual(400, progress.MaxCompletionScore);
        Assert.AreEqual(11629.93m, progress.MaxFlowDist);

        Assert.IsNotNull(progress.Flows);
        Assert.AreEqual(4, progress.Flows.Count);

        var flows = progress.Flows;

        Assert.AreEqual(7333.72m, flows[0].FarFlowDist);
        Assert.AreEqual(9998.64m, flows[0].CurFlowDist);

        Assert.AreEqual(9998.64m, flows[1].FarFlowDist);
        Assert.AreEqual(7277.55m, flows[1].CurFlowDist);

        Assert.AreEqual(8428.84m, flows[2].FarFlowDist);
        Assert.AreEqual(8428.84m, flows[2].CurFlowDist);

        Assert.AreEqual(7926.63m, flows[3].FarFlowDist);
        Assert.AreEqual(9998.64m, flows[3].CurFlowDist);

        Assert.AreEqual(line, progress.ToString());
    }
}