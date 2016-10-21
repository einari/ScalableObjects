using System;
using System.Diagnostics;

namespace Admin
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                ServiceEventSource.Current.Message("Starting node");
                var processStartInfo = new ProcessStartInfo("node.exe", "bin/www");
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.UseShellExecute = false;

                var process = new Process();

                process.StartInfo = processStartInfo;
                process.Start();

                ServiceEventSource.Current.Message("Node started");

                process.StandardOutput.ReadToEndAsync().ContinueWith(t=> {
                    ServiceEventSource.Current.Message($"Output : {t.Result}");
                    Console.WriteLine($"{t.Result}");
                });
                
                process.WaitForExit();
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
