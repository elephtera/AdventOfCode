using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Helpers
{
    public static class FunctionExtensions
    {
        // Function with 1 argument
        public static Func<TArgument, TResult> Memoize<TArgument, TResult>
        (
            this Func<TArgument, TResult> func
        ) where TArgument : notnull
        {
            var cache = new ConcurrentDictionary<TArgument, TResult>();

            return argument => cache.GetOrAdd(argument, func);
        }

        // Function with 2 arguments
        public static Func<TArgument1, TArgument2, TResult> Memoize<TArgument1, TArgument2, TResult>
        (
            this Func<TArgument1, TArgument2, TResult> func
        )
        {
            var cache = new ConcurrentDictionary<(TArgument1, TArgument2), TResult>();

            return (argument1, argument2) =>
                cache.GetOrAdd((argument1, argument2), tuple => func(tuple.Item1, tuple.Item2));
        }
    }
}
