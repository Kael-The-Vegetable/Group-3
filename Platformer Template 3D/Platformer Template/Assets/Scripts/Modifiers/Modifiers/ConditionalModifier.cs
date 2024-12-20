using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A modifier that is only applied if  <see cref="Condition"/> evaluates true.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class ConditionalModifier<TValue> : IModifier<TValue>
{
    public IModifier<TValue> Modifier { get; set; }
    public Func<bool> Condition { get; private set; }

    public ConditionalModifier(IModifier<TValue> modifier, Func<bool> condition)
    {
        Modifier = modifier;
        Condition = condition;
        Order = modifier.Order;
    }

    public int Order { get; private set; }

    int IModifier<TValue>.Order => Order;

    TValue IModifier<TValue>.ApplyModifier(TValue baseValue, TValue modValue)
    {
        return Condition() ? Modifier.ApplyModifier(baseValue, modValue) : modValue;
    }
}
