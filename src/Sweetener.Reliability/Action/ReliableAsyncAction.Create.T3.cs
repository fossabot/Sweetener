// Generated from ReliableAsyncAction.Create.tt
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sweetener.Reliability
{
    partial class ReliableAsyncAction
    {
        /// <summary>
        /// Creates a new <see cref="ReliableAsyncAction{T1, T2, T3}"/>
        /// that executes the given asynchronous action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAsyncAction<T1, T2, T3> Create<T1, T2, T3>(
            Func<T1, T2, T3, Task> action,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableAsyncAction<T1, T2, T3>(action, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncAction{T1, T2, T3}"/>
        /// that executes the given asynchronous action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAsyncAction<T1, T2, T3> Create<T1, T2, T3>(
            Func<T1, T2, T3, Task> action,
            int                 maxRetries,
            ExceptionHandler    exceptionHandler,
            ComplexDelayHandler delayHandler)
            => new ReliableAsyncAction<T1, T2, T3>(action, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncAction{T1, T2, T3}"/>
        /// that executes the given asynchronous action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAsyncAction<T1, T2, T3> Create<T1, T2, T3>(
            Func<T1, T2, T3, CancellationToken, Task> action,
            int              maxRetries,
            ExceptionHandler exceptionHandler,
            DelayHandler     delayHandler)
            => new ReliableAsyncAction<T1, T2, T3>(action, maxRetries, exceptionHandler, delayHandler);

        /// <summary>
        /// Creates a new <see cref="ReliableAsyncAction{T1, T2, T3}"/>
        /// that executes the given asynchronous action at most a specific number of times
        /// based on the provided policies.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this reliable delegate encapsulates.</typeparam>
        /// <param name="action">The action to encapsulate.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="exceptionHandler">A function that determines which errors are transient.</param>
        /// <param name="delayHandler">A function that determines how long wait to wait between retries.</param>
        /// <returns>A reliable delegate that encapsulates the <paramref name="action" />.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="action" />, <paramref name="exceptionHandler" />, or <paramref name="delayHandler" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxRetries" /> is a negative number other than <c>-1</c>, which represents an infinite number of retries.
        /// </exception>
        public static ReliableAsyncAction<T1, T2, T3> Create<T1, T2, T3>(
            Func<T1, T2, T3, CancellationToken, Task> action,
            int                 maxRetries,
            ExceptionHandler    exceptionHandler,
            ComplexDelayHandler delayHandler)
            => new ReliableAsyncAction<T1, T2, T3>(action, maxRetries, exceptionHandler, delayHandler);
    }
}
