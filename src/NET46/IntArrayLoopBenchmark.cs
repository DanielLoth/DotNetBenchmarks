using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace NET46
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]

    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [MarkdownExporterAttribute.Default]
    [MarkdownExporterAttribute.GitHub]
    public class IntArrayLoopBenchmark
    {
        public static int N = 1000;
        public static int[] Array = new int[N];

        private class Config : ManualConfig
        {
            public Config()
            {
                // Same as having the class-level attribute.
                // Add(MemoryDiagnoser.Default);

                Add(StatisticColumn.AllStatistics);
            }
        }

        [Benchmark]
        public void ForeachLoop()
        {
            foreach (int i in Array)
            {
                ;
            }
        }

        [Benchmark]
        public void IndexerLoop()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                int value = Array[i];
            }
        }
    }
}
