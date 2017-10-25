using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

namespace NET46
{
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FlagEnumBenchmarks
    {
        private MyFlags flags = MyFlags.A | MyFlags.C | MyFlags.E;
        private byte bitmask = BitA | BitC | BitE;

        [Benchmark(OperationsPerInvoke = 64)]
        public void EnumHasFlag()
        {
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();

            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();

            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();

            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
            CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag(); CheckEnumHasFlag();
        }

        [Benchmark(OperationsPerInvoke = 64)]
        public void Enum()
        {
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();

            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();

            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();

            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
            CheckEnum(); CheckEnum(); CheckEnum(); CheckEnum();
        }

        [Benchmark(OperationsPerInvoke = 64)]
        public void Bitwise()
        {
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();

            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();

            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();

            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
            CheckBitwise(); CheckBitwise(); CheckBitwise(); CheckBitwise();
        }

        private bool CheckBitwise()
        {
            return (bitmask & BitC) != 0;
        }

        private bool CheckEnumHasFlag()
        {
            return flags.HasFlag(MyFlags.C);
        }

        private bool CheckEnum()
        {
            return (flags & MyFlags.C) != 0;
        }

        private const byte BitA = (1 << 0);
        private const byte BitB = (1 << 1);
        private const byte BitC = (1 << 2);
        private const byte BitD = (1 << 3);
        private const byte BitE = (1 << 4);
        private const byte BitF = (1 << 5);
        private const byte BitG = (1 << 6);
        private const byte BitH = (1 << 7);

        [Flags]
        private enum MyFlags : byte
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }
    }
}
