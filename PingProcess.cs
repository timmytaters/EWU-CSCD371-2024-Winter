using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }
    //Bullet 1
    /*Implement PingProcess' public Task<PingResult> RunTaskAsync(string hostNameOrAddress) ❌✔
    First implement public void RunTaskAsync_Success() test method to test PingProcess.RunTaskAsync() using "localhost". ❌✔
    Do NOT use async/await in this implementation. 
     */
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));
    }

    //Bullet 2 & 3
    /*Implement PingProcess' async public Task<PingResult> RunAsync(string hostNameOrAddress) ❌✔
    First implement the public void RunAsync_UsingTaskReturn_Success() test method to test PingProcess.RunAsync() using "localhost" without using async/await. ❌✔
    Also implement the async public Task RunAsync_UsingTpl_Success() test method to test PingProcess.RunAsync() using "localhost" but this time DO using async/await. ❌✔
    Add support for an optional cancellation token to the PingProcess.RunAsync() signature. ❌✔ Inside the PingProcess.RunAsync() invoke the token's ThrowIfCancellationRequested() 
    method so an exception is thrown. ❌✔ Test that, when cancelled from the test method, the exception thrown is an AggregateException ❌✔ with a TaskCanceledException inner 
    exception ❌✔ using the test methods RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping ❌✔and 
    RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException ❌✔ respectively.
     */

    //Implement PingProcess' async public Task<PingResult> RunAsync(string hostNameOrAddress)
    //Add support for an optional cancellation token to the PingProcess.RunAsync() signature
    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        try
        {
            //Inside the PingProcess.RunAsync() invoke the token's ThrowIfCancellationRequested() method so an exception is thrown.
            cancellationToken.ThrowIfCancellationRequested();
            PingResult result = await Task.Run<PingResult>(() => { return Run(hostNameOrAddress); }, cancellationToken);
            return result;
        }
        //when cancelled from the test method, the exception thrown is an AggregateException ❌✔ with a TaskCanceledException inner exception
        catch (OperationCanceledException)
        {
            TaskCanceledException tce = new();
            AggregateException Ae = new(tce);
            throw Ae;
        }
    }
    //Bullet 4
    /*
     * Complete/fix AND test async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default) 
     * which executes ping for an array of hostNameOrAddresses (which can all be "localhost") in parallel, adding synchronization if needed. ❌✔ NOTE:
    The order of the items in the stdOutput is irrelevant and expected to be intermingled.
    StdOutput must have all the ping output returned (no lines can be missing) even though intermingled. ❌✔
     */
    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        int code = 0;
        StringBuilder sB = new();
        //adding synchronization if needed.
        //Synchronize, one at a time
        var semaphore = new SemaphoreSlim(1);
        //which executes ping for an array of hostNameOrAddresses (which can all be "localhost") in parallel
        var tasks = hostNameOrAddresses.Select(async item =>
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                PingResult result = await RunAsync(item, cancellationToken);
                if (result.StdOutput != null)
                {
                    await semaphore.WaitAsync(cancellationToken);
                    try
                    { 
                        code = 1;
                        sB.AppendLine(result.StdOutput.Trim());
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            }
            //The order of the items in the stdOutput is irrelevant and expected to be intermingled.
            //StdOutput must have all the ping output returned(no lines can be missing) even though intermingled
            catch (Exception ex)
            {
                await semaphore.WaitAsync(cancellationToken);
                try{sB.AppendLine("Error pinging "+item+": "+ex.Message+", ");}
                finally{semaphore.Release();}
            }
        });

        await Task.WhenAll(tasks);
        return new PingResult(code, sB.ToString());
}
    //Bullet 5
    /*
     * Implement AND test public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token) 
     * using Task.Factory.StartNew() and invoking RunProcessInternal with a TaskCreation value of TaskCreationOptions.LongRunning and a TaskScheduler value of 
     * TaskScheduler.Current. Returning a Task<PingResult> is also okay. NOTE: This method does NOT use Task.Run.
     */
    public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
        //using Task.Factory.StartNew() and invoking RunProcessInternal with a TaskCreation value of TaskCreationOptions.LongRunning and a TaskScheduler value of TaskScheduler.Current.
        return Task.Factory.StartNew(() =>
        {
            var process = new Process{StartInfo = UpdateProcessStartInfo(startInfo)};
            RunProcessInternal(process, progressOutput, progressError, token);
            return process.ExitCode;
        }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }


    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}