using System;
using System.Collections;
using Moq.Language.Flow;

namespace ASCOM.Alpaca.Client.Test
{
    internal static class MoqExtensions
    {
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup, params object[] results) where T : class {
            var queue = new Queue(results);
            setup.Returns(() => {
                var result = queue.Dequeue();
                if (result is Exception) {
                    throw result as Exception;
                }
                return (TResult)result;
            });
        }
        
        public static void ReturnsInOrder<TMock, TResult>(this IReturnsThrows<TMock, TResult> setup, params object[] results) where TMock : class {
            var queue = new Queue(results);
            setup.Returns(() => {
                var result = queue.Dequeue();
                if (result is Exception) {
                    throw result as Exception;
                }
                return (TResult)result;
            });
        }
    }
}