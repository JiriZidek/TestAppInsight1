using System;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

// https://docs.microsoft.com/en-us/azure/azure-monitor/app/console

namespace TestAppInsight1
{
    class Program
    {

        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            // Here a real key is needed

            TelemetryConfiguration.Active.InstrumentationKey = "CODE";
            var tc = new TelemetryClient();

            for(var i = 0; i < 60; i++) {
                Console.WriteLine(i);
                switch(i % 5) {
                    case 0: tc.TrackTrace("Normal trace"); break;
                    case 1: tc.TrackException(new InvalidOperationException("Test Exception")); break;
                    case 2: tc.TrackPageView("http://www.atlantis.cz"); break;
                    case 3: tc.TrackRequest("Normal Request", DateTime.Now, TimeSpan.FromMilliseconds(300 + i), "200 OK", i % 2 == 0); break;
                    case 4: tc.TrackEvent("Normal Event"); break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
