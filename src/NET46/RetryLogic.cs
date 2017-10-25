using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET46
{
    public class RetryLogic
    {
        static void Execute(Action operation)
        {
            Execute(operation, os =>
            {
                os();
                return true;
            });
        }

        static void Execute<T1, T2>(T1 arg1, T2 arg2, Action<T1, T2> operation)
        {
            Execute(operation, os =>
            {
                os(arg1, arg2);
                return true;
            });
        }

        static TResult Execute<TArg1, TArg2, TArg3, TResult>(
            Func<TArg1, TArg2, TArg3, TResult> operation,
            TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var result = operation(arg1, arg2, arg3);
            return result;
        }

        static void Execute<TResult>(Func<TResult> operation)
        {
            Execute(new { operation }, os =>
            {
                Exception mostRecentException = null;
                var retryCount = 3;

                for (var i = 0; i < retryCount; i++)
                {
                    try
                    {
                        var result = os.operation();

                        return result;
                    }
                    catch (Exception ex)
                    {
                        mostRecentException = ex;
                    }
                }

                throw mostRecentException;
            });
        }

        static void Execute<TState>(TState state, Action<TState> operation)
        {
            Execute(new { operation, state }, s =>
            {
                s.operation(s.state);
                return true;
            });
        }

        static TResult Execute<TState, TResult>(
            TState state,
            Func<TState, TResult> operation)
        {
            var result = operation(state);
            return result;
        }

        public static void Test()
        {
            Execute(GetInt);
            Execute(GetIntTuple);
            var result = Execute(5, Double);

            var result2 = Execute(Blah, 2, 3, 4);

            //var c = Execute(Double);
        }

        private static int GetInt()
        {
            return 2;
           // throw new InvalidOperationException();
        }

        private static void Nothing()
        {

        }

        private static int Double(int a)
        {
            return 2 * a;
        }

        private static int Blah(int a, int b, int c)
        {
            return a * b * c * 2;
        }

        private static Tuple<int, int> GetIntTuple()
        {
            return new Tuple<int, int>(1, 1);
        }
    }
}
