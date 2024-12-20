using System.Collections.Generic;
using System.Linq;

public class ModifierList<T>
{
    private List<IModifier<T>> _modifiers = new();

    public IModifier<T> this[int i] => _modifiers[i];
    public int Count => _modifiers.Count;

    public void Add(IModifier<T> modifier)
    {
        _modifiers.Add(modifier);
        _modifiers = _modifiers.OrderBy(m => m.Order).ToList();
    }

    public void Remove(IModifier<T> modifier)
    {
        _modifiers.Remove(modifier);
    }

    public void Clear()
    {
        _modifiers.Clear();
    }

    /// <summary>
    /// <inheritdoc cref="ModifierList.ApplyModifiers{T}(IEnumerable{IModifier{T}}, T)"/>
    /// </summary>
    /// <param name="baseValue"><inheritdoc cref="ModifierList.ApplyModifiers{T}(IEnumerable{IModifier{T}}, T)"/></param>
    /// <returns><inheritdoc cref="ModifierList.ApplyModifiers{T}(IEnumerable{IModifier{T}}, T)"/></returns>
    public T ApplyModifiers(T baseValue)
    {
        return _modifiers.ApplyModifiers(baseValue);
    }
}

public static class ModifierList
{
    /// <summary>
    /// Applies every modifier in the list to a given <paramref name="baseValue"/>.
    /// </summary>
    /// <param name="baseValue">The base value to be modified.</param>
    /// <returns>The modified value.</returns>
    public static T ApplyModifiers<T>(this IEnumerable<IModifier<T>> modifiers, T baseValue)
    {
        var modValue = baseValue;

        foreach (var modifier in modifiers)
        {
            if (!modifier.Equals(default))
            {
                modValue = modifier.ApplyModifier(baseValue, modValue);
            }
        }

        return modValue;
    }
}