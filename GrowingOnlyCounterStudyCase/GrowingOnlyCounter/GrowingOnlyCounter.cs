using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CRDTs;

public class GrowingOnlyCounter
{
    private ConcurrentDictionary<string, int> _counters = new ConcurrentDictionary<string, int>();

    // Create a new GrowingOnlyCounter with a unique identifier
    public GrowingOnlyCounter() : this(Guid.NewGuid())
    {
    }

    // Create a new GrowingOnlyCounter with a specified unique identifier
    public GrowingOnlyCounter(Guid uid)
    {
        _counters.TryAdd(uid.ToString(), 0);
    }

    public int Value => _counters.Values.Sum();

    public void Increment(Guid uid)
    {
        _counters.AddOrUpdate(uid.ToString(), 1, (key, oldValue) => oldValue + 1);
    }

    public void Merge(GrowingOnlyCounter other)
    {
        foreach (var counter in other._counters)
        {
            _counters.AddOrUpdate(counter.Key, counter.Value, (key, oldValue) => Math.Max(oldValue, counter.Value));
        }
    }
}
