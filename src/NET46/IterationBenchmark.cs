using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Toolchains.InProcess;
using System.Collections.Generic;

namespace NET46
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles]

    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [RPlotExporter]
    [JsonExporterAttribute.Brief]
    [JsonExporterAttribute.BriefCompressed]
    [JsonExporterAttribute.Full]
    [JsonExporterAttribute.FullCompressed]
    [MarkdownExporterAttribute.Default]
    [MarkdownExporterAttribute.GitHub]
    [MarkdownExporterAttribute.StackOverflow]
    [MarkdownExporterAttribute.Atlassian]
    public class IterationBenchmark
    {
        public static readonly int N = 2000;
        public List<int> list;
        public IList<int> ilist;

        public HashSet<int> hashSet;
        public ISet<int> iSetHashSet;

        public SortedSet<int> sortedSet;
        public ISet<int> iSetSortedSet;

        public int[] array;

        private class Config : ManualConfig
        {
            public Config()
            {
                //Add(StatisticColumn.AllStatistics);
                Add(VeryFastJobForMemoryDiagnosis); // Comment out this line to run regular benchmark
            }
        }

        public static readonly Job VeryFastJobForMemoryDiagnosis = new Job("Competition")
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

        [Setup]
        public void Setup()
        {
            list = new List<int>(N);
            ilist = list;

            array = new int[N];

            for (int i = 0; i < N; i++)
            {
                list.Add(i);
                array[i] = i;
            }

            hashSet = new HashSet<int>(array);
            iSetHashSet = hashSet;

            sortedSet = new SortedSet<int>(array);
            iSetSortedSet = sortedSet;
        }

        [Benchmark]
        public void IterateList()
        {
            foreach (var value in list)
            {
                ;
            }
        }

        [Benchmark]
        public void IterateIList()
        {
            foreach (var value in ilist)
            {
                ;
            }
        }

        [Benchmark(Baseline =true)]
        public void IterateArray()
        {
            foreach (var value in array)
            {
                ;
            }
        }

        [Benchmark]
        public void IterateHashSet()
        {
            foreach (var value in hashSet)
            {
                ;
            }
        }

        [Benchmark]
        public void IterateISetHashSet()
        {
            foreach (var value in iSetHashSet)
            {
                ;
            }
        }

        [Benchmark]
        public void IterateSortedSet()
        {
            foreach (var value in sortedSet)
            {
                ;
            }
        }

        [Benchmark]
        public void IterateISetSortedSet()
        {
            foreach (var value in iSetSortedSet)
            {
                ;
            }
        }
    }
}
