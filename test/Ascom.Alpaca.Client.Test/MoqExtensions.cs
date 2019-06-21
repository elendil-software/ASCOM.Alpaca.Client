using System;
using System.Collections;
using Moq.Language.Flow;

namespace ES.AscomAlpaca.Client.Test
{
    /// <summary>
    /// Extensions methods based on this blog post : https://haacked.com/archive/2010/11/24/moq-sequences-revisited.aspx/
    /// </summary>
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