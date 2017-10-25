using BenchmarkDotNet.Running;
using System.Reflection;

namespace NET46
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program)
                .GetTypeInfo().Assembly).Run(args);

            //RetryLogic.Test();

            //var range = default(Range<int>);
            //var range2 = new Range<int>(1, 5);

            //var size = Marshal.SizeOf(typeof(Range<int>));
            //var a = GetSize(typeof(Range<long>));
            //var b = GetSize(typeof(Range<int>));
            //var c = GetSize(typeof(Range<double>));
            //var d = GetSize(typeof(Range<decimal>));
        }

        //static int GetSize(Type t)
        //{
        //    var dm = new DynamicMethod("SizeOfType", typeof(int), new Type[] { });
        //    ILGenerator il = dm.GetILGenerator();
        //    il.Emit(OpCodes.Sizeof, t);
        //    il.Emit(OpCodes.Ret);
        //    return (int)dm.Invoke(null, null);
        //}
    }
}
