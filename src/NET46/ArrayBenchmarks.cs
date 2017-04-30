using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;

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
    public class ArrayBenchmarks
    {
        public static int SmallN = 100;
        public static int N = 1000;

        public int[] oneDimensionTo2d = new int[N * N];
        public int[,] twoDimensions = new int[N, N];
        public int[,,] threeDimensions = new int[SmallN, SmallN, SmallN];

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
        public void OneDimensionOneLoop()
        {
            int value = 0;
            for (int i = 0; i < oneDimensionTo2d.Length; i++)
            {
                value = oneDimensionTo2d[i];
            }
        }

        [Benchmark]
        public void OneDimensionA()
        {
            int value = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    value = oneDimensionTo2d[i * N + j];
                }
            }
        }


        [Benchmark]
        public void OneDimensionB()
        {
            int value = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    value = oneDimensionTo2d[j * N + i];
                }
            }
        }

        [Benchmark(Baseline = true)]
        public void TwoDimensionsD1ThenD2()
        {
            int value = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    value = twoDimensions[i, j];
                }
            }
        }

        [Benchmark]
        public void TwoDimensionsD2ThenD1()
        {
            int value = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    value = twoDimensions[j, i];
                }
            }
        }

        [Benchmark]
        public void ThreeDimensionsD1D2D3()
        {
            int value = 0;

            for (int i = 0; i < SmallN; i++)
            {
                for (int j = 0; j < SmallN; j++)
                {
                    for (int k = 0; k < SmallN; k++)
                    {
                        value = threeDimensions[i, j, k];
                    }
                }
            }
        }

        [Benchmark]
        public void ThreeDimensionsD3D2D1()
        {
            int value = 0;

            for (int i = 0; i < SmallN; i++)
            {
                for (int j = 0; j < SmallN; j++)
                {
                    for (int k = 0; k < SmallN; k++)
                    {
                        value = threeDimensions[k, j, i];
                    }
                }
            }
        }
    }
}
