using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using Thinktecture.IdentityServer.Core.Logging;

namespace SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "IdentityServer3 SelfHost";
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            var url = ConfigurationManager.AppSettings["Url"];
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", url);
                Console.ReadLine();
            }
        }
    }
}