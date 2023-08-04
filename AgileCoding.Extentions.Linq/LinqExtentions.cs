namespace AgileCoding.Extentions.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LinqExtentions
    {
        public static TSource? TakeTop<TSource>(this List<TSource> source)
        {
            if (source.Count == 0)
            {
                return default(TSource);
            }
            else
            {
                var topItem = source[0];
                source.RemoveAt(0);
                return topItem;
            }
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch")
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IList<TSource>? list = source as IList<TSource>;

            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        throw new InvalidOperationException(noElementsMessage);
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        throw new InvalidOperationException(noElementsMessage);
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            throw new InvalidOperationException(moreThanOneMatchMessage);
        }

        public static TSource Single<TSource>(this IQueryable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch")
        {
            return Single<TSource>(source.ToList(), noElementsMessage, moreThanOneMatchMessage);
        }

        public static TSource Single<TSource, TNoElementsExceptionType, TMoreThanOnceExceptionType>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch") where TNoElementsExceptionType : Exception where TMoreThanOnceExceptionType : Exception
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IList<TSource>? list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        var noElementException = Activator.CreateInstance(typeof(TNoElementsExceptionType), noElementsMessage) as TNoElementsExceptionType;
                        if(noElementException != null)
                        {
                            throw noElementException;
                        }
                        else
                        {
                            throw new InvalidOperationException(noElementsMessage);
                        }
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        var noElementException = Activator.CreateInstance(typeof(TNoElementsExceptionType), noElementsMessage) as TNoElementsExceptionType;
                        if (noElementException != null)
                        {
                            throw noElementException;
                        }
                        else
                        {
                            throw new InvalidOperationException(noElementsMessage);
                        }
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            var exception = Activator.CreateInstance(typeof(TMoreThanOnceExceptionType), moreThanOneMatchMessage) as TMoreThanOnceExceptionType;
            if (exception != null)
            {
                throw exception;
            }
            else
            {
                throw new InvalidOperationException(moreThanOneMatchMessage);
            }
        }

        public static TSource? SingleOrDefault<TSource>(this IEnumerable<TSource> source, string moreThanOneMatchMessage = "MoreThanOneMatch")
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IList<TSource>? list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        return default(TSource);
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return default(TSource);
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            throw new InvalidOperationException(moreThanOneMatchMessage);
        }

        public static TSource? SingleOrDefault<TSource, TMoreThanOnceExceptionType>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch") where TMoreThanOnceExceptionType : Exception
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IList<TSource>? list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        return default(TSource);
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return default(TSource);
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            var exception = Activator.CreateInstance(typeof(TMoreThanOnceExceptionType), moreThanOneMatchMessage) as TMoreThanOnceExceptionType;
            if (exception != null)
            {
                throw exception;
            }
            else
            {
                throw new InvalidOperationException(moreThanOneMatchMessage);
            }
        }

        //public static TSource Any<TSource, TFoundAnyItemsExceptionType>(this IEnumerable<TSource> source,
        //    string foundAnyElementsExceptionMessage = "ElementsFound")
        //    where TFoundAnyItemsExceptionType : Exception
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    IList<TSource> list = source as IList<TSource>;
        //    if (list != null && list.Count >= 1)
        //    {
        //        throw (TFoundAnyItemsExceptionType)Activator.CreateInstance(typeof(TFoundAnyItemsExceptionType), foundAnyElementsExceptionMessage);
        //    }
        //    else
        //    {
        //        return (TSource)source;
        //    }
        //}
        public static TSource? First<TSource, TNoElementsExceptionType>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements")
            where TNoElementsExceptionType : Exception
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IList<TSource>? list = source as IList<TSource>;
            if (list != null)
            {
                if (list.Count == 0)
                {
                    var exception = Activator.CreateInstance(typeof(TNoElementsExceptionType), noElementsMessage) as TNoElementsExceptionType;
                    if(exception != null)
                    {
                        throw exception;
                    }
                    else
                    {
                        throw new InvalidOperationException(noElementsMessage);
                    }
                }
                else if (list.Count >= 1)
                {
                    return list[0];
                }
                else
                {
                    return default(TSource);
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        var exception = Activator.CreateInstance(typeof(TNoElementsExceptionType), noElementsMessage) as TNoElementsExceptionType;
                        if (exception != null)
                        {
                            throw exception;
                        }
                        else
                        {
                            throw new InvalidOperationException(noElementsMessage);
                        }
                    }
                    else if (!enumerator.MoveNext())
                    {
                        return enumerator.Current;
                    }
                }
            }

            return default(TSource);
        }
    }
}
