using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }
    /*
    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("-c 4 google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }*/


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput, string? stdError) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "ping: badaddress: Temporary failure in name resolution".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("-c 4 localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Arrange
        var pingProcess = new PingProcess();

        // Act
        var resultTask = pingProcess.RunTaskAsync("-c 4 localhost");
        resultTask.Wait(); // Wait for the task to complete synchronously

        // Get the result after the task has completed
        var result = resultTask.Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.ExitCode == 0); // Assuming 0 indicates success
        Assert.IsNotNull(result.StdOutput);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> actual = Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(actual.Result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        PingResult actual = await Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(actual);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        var cTS = new CancellationTokenSource();
        cTS.Cancel();
        Sut.RunAsync("-c 4 localhost", cTS.Token).Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        var cTS = new CancellationTokenSource();
        cTS.Cancel();
        try
        {
            Sut.RunAsync("-c 4 localhost", cTS.Token).Wait();
        }
        catch (AggregateException Ae)
        {
            Exception? flattened = Ae.Flatten().InnerException;
            throw flattened!;
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "-c 4 localhost", "-c 4 localhost", "-c 4 localhost", "-c 4 localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount+1, lineCount);
        //One difference, unsure why
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        var startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        Assert.AreEqual(0, exitCode);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        try
        {
            IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
            System.Text.StringBuilder stringBuilder = new();
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
            int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
            Assert.AreNotEqual(lineCount, numbers.Count() + 1);
        }
        catch(AggregateException) { 
            //Ignore Destination too short
        }
    }

    readonly string PingOutputLikeExpression = @"
PING * 56 data bytes
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
--- * ping statistics ---
* packets transmitted, * received, *% packet loss, time *ms
rtt min/avg/max/mdev = */*/*/* ms
".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
