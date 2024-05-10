﻿using System.Collections.Generic;

namespace System.Linq; // To extend Microsoft's namespace.

public static class LinqExtensions
{
    // This is a chainable LINQ extension method.
    public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
    {
        // You could do some processing here.
        return sequence;
    }

    public static IQueryable<T> ProcessSequence<T>(this IQueryable<T> sequence)
    {
        // You could do some processing here.
        return sequence;
    }

    // These are scalar LINQ extension methods.
    public static int? Median(this IEnumerable<int?> sequence)
    {
        var ordered = sequence.OrderBy(item => item);
        int middlePosition = ordered.Count() / 2;

        return ordered.ElementAt(middlePosition);
    }

    public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
    {
        return sequence.Select(selector).Median();
    }

    public static decimal? Median(this IEnumerable<decimal?> sequence)
    {
        var ordered = sequence.OrderBy(item => item);
        int middlePosition = ordered.Count() / 2;

        return ordered.ElementAt(middlePosition);
    }

    public static decimal? Median<T>(this IEnumerable<T> sequence, Func<T, decimal?> selector)
    {
        return sequence.Select(selector).Median();
    }

    public static int? Mode(this IEnumerable<int?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);
        var orderedGroups = grouped.OrderByDescending(group => group.Count());
        
        return orderedGroups.FirstOrDefault()?.Key;
    }

    public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
    {
        return sequence.Select(selector)?.Mode();
    }

    public static decimal? Mode(this IEnumerable<decimal?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);
        var orderedGroups = grouped.OrderByDescending(group => group.Count());
        
        return orderedGroups.FirstOrDefault()?.Key;
    }

    public static decimal? Mode<T>(this IEnumerable<T> sequence, Func<T, decimal?> selector)
    {
        return sequence.Select(selector).Mode();
    }
}