using BenchmarkDotNet.Attributes;
using System;
using System.Diagnostics;

namespace NET46
{
    public class TimingBenchmarks
    {
        public static int N = 100000;
        private static readonly Stopwatch stopwatch = new Stopwatch();

        /*
            // * Summary *

            BenchmarkDotNet=v0.10.5, OS=Windows 10.0.14393
            Processor=Intel Core i7-2600K CPU 3.40GHz (Sandy Bridge), ProcessorCount=8
            Frequency=3331180 Hz, Resolution=300.1939 ns, Timer=TSC
              [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0
              DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2053.0


                     Method |     Mean |     Error |    StdDev |
            --------------- |---------:|----------:|----------:|
             DateTimeUtcNow | 41.22 ns | 0.1011 ns | 0.0844 ns |
                  Stopwatch | 53.25 ns | 0.8975 ns | 0.7956 ns |

            // * Hints *
            Outliers
              TimingBenchmarks.DateTimeUtcNow: Default -> 2 outliers were removed
              TimingBenchmarks.Stopwatch: Default      -> 1 outlier  was  removed

            // * Legends *
              Mean   : Arithmetic mean of all measurements
              Error  : Half of 99.9% confidence interval
              StdDev : Standard deviation of all measurements

            // ***** BenchmarkRunner: End *****
         */

        [Setup]
        public void Setup()
        {
            stopwatch.Start();
        }

        [Benchmark]
        public TimeSpan DateTimeUtcNow()
        {
            var timespan = TimeSpan.MinValue;

            timespan += DateTime.UtcNow.TimeOfDay;

            return timespan;
        }

        /// <summary>
        /// This one is shit - don't even bother.
        /// </summary>
        /// <returns></returns>
        //[Benchmark]
        //public TimeSpan DateTimeNow()
        //{
        //    var timespan = TimeSpan.MinValue;

        //    for (var i = 0; i < N; i++)
        //    {
        //        timespan += DateTime.Now.TimeOfDay;
        //    }

        //    return timespan;
        //}

        [Benchmark]
        public TimeSpan Stopwatch()
        {
            var timespan = TimeSpan.MinValue;

            timespan += stopwatch.Elapsed;

            return timespan;
        }
    }
}
