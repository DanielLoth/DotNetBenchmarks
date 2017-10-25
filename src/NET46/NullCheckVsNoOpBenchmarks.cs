using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Toolchains.InProcess;

namespace NET46
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    public class NullCheckVsNoOpBenchmarks
    {
        /*
        // * Summary *

        BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 2 (10.0.15063)
        Processor=Intel Core i7-2600K CPU 3.40GHz (Sandy Bridge), ProcessorCount=8
        Frequency=3331185 Hz, Resolution=300.1935 ns, Timer=TSC
          [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0
          DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2102.0


                 Method |     Mean |     Error |    StdDev |
        --------------- |---------:|----------:|----------:|
              NullCheck | 1.624 ns | 0.0006 ns | 0.0005 ns |
         NoOpInvocation | 1.688 ns | 0.0002 ns | 0.0002 ns |

        // * Hints *
        Outliers
          NullCheckVsNoOpBenchmarks.NullCheck: Default      -> 1 outlier  was  removed
          NullCheckVsNoOpBenchmarks.NoOpInvocation: Default -> 3 outliers were removed

        // * Legends *
          Mean   : Arithmetic mean of all measurements
          Error  : Half of 99.9% confidence interval
          StdDev : Standard deviation of all measurements
          1 ns   : 1 Nanosecond (0.000000001 sec)

        // ***** BenchmarkRunner: End *****

        Global total time: 00:00:50 (50.62 sec)
        */

        private class Config : ManualConfig
        {
            public Config()
            {
                // Same as having the class-level attribute.
                Add(MemoryDiagnoser.Default);
                //Add(StatisticColumn.AllStatistics);
                Add(DefaultJob);
            }
        }

        public static readonly Job DefaultJob = new Job("Competition")
        {
            Env =
            {
                Gc =
                {
                    Force = false
                }
            },
            Run =
            {
                LaunchCount = 1,
                WarmupCount = 16,
                TargetCount = 16,
                RunStrategy = RunStrategy.Throughput,
                UnrollFactor = 16,
                InvocationCount = 16
            },
            Infrastructure =
            {
                Toolchain = InProcessToolchain.DontLogOutput
            }
        }.Freeze();

        private interface ISomething
        {
            void DoSomething();
        }

        private class NoOpSomething : ISomething
        {
            void ISomething.DoSomething()
            {
                // Nothing.
            }
        }

        private static readonly ISomething noOpSomething = new NoOpSomething();
        private static readonly ISomething nullSomething = null;

        [Benchmark(OperationsPerInvoke = 32)]
        public void NullCheck()
        {
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();

            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
            NullCheckInternal(); NullCheckInternal(); NullCheckInternal(); NullCheckInternal();
        }

        private static void NullCheckInternal()
        {
            if (nullSomething != null)
            {
                nullSomething.DoSomething();
            }
        }

        [Benchmark(OperationsPerInvoke = 32)]
        public void NoOpInvocation()
        {
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();

            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
            NoOpInternal(); NoOpInternal(); NoOpInternal(); NoOpInternal();
        }

        private static void NoOpInternal()
        {
            noOpSomething.DoSomething();
        }
    }
}
