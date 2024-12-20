using System.Collections.Generic;
using System.Linq;

public class ModifierList<T>
{
    private List<IModifier<T>> _modifiers;

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
    /// Additively applies every modifier in the list to a given <paramref name="baseValue"/>.
    /// </summary>
    /// <param name="baseValue"></param>
    /// <returns>The modified value.</returns>
    public T ApplyModifiers(T baseValue)
    {
        var modValue = baseValue;

        foreach (var modifier in _modifiers)
        {
            if (!modifier.Equals(default))
            {
                modValue = modifier.ApplyModifier(baseValue, modValue);
            }
        }

        return modValue;
    }
}