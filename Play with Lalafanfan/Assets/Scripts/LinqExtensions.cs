using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LinqExtensions
{
    public static IEnumerable<T> Do<T>(this IEnumerable<T> self, Action<T> action)
    {
        foreach (var item in self)
        {
            action(item);
            yield return item;
        }
    }
}
