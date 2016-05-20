﻿using System;
using System.Diagnostics;
using System.Threading;

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

                //var process = Process.Start(processStartInfo);
                //Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }

            /*
            try
            {
                ServiceRuntime.RegisterServiceAsync("AdminType",
                    context => new Admin(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Admin).Name);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }*/
        }
    }
}