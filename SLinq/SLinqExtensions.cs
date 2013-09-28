using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace SLinq
{
    public static class SLinqExtensions
    {
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource compare) 
            where TSource : IEquatable<TSource>
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Equals(compare))
                        return true;
                }
            }
            return false;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires(source != null);

            int count = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;
                }
            }

            return count;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }

            throw new InvalidOperationException("sequence contains no elements");
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }

            return default(TSource);
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    TSource result;
                    do
                    {
                        result = enumerator.Current;
                    } while (enumerator.MoveNext());

                    return result;
                }
            }

            throw new InvalidOperationException("sequence contains no elements");
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    TSource result;
                    do
                    {
                        result = enumerator.Current;
                    } while (enumerator.MoveNext());

                    return result;
                }
            }

            return default(TSource);
        }

        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int number)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                int counter = 0;
                while (enumerator.MoveNext())
                {
                    if (number < ++counter)
                        yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int number)
        {
            Contract.Requires(source != null);

            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                int counter = 0;
                while (enumerator.MoveNext() && counter++ < number)
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Contract.Requires(source != null);
            Contract.Requires(predicate != null);

            foreach (var s in source)
                if (predicate(s))
                    yield return s;
        }
    }
}
