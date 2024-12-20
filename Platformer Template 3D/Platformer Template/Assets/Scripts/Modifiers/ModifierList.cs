using System.Collections.Generic;

public class ModifierList<T> : List<IModifier<T>>
{
    /// <summary>
    /// Additively applies every modifier in the list to a given <paramref name="baseValue"/>.
    /// </summary>
    /// <param name="baseValue"></param>
    /// <returns>The modified value.</returns>
    public T ApplyModifiersAdditive(T baseValue)
    {
        var modValue = baseValue;

        foreach (var modifier in this)
        {
            if (!modifier.Equals(default))
            {
                modValue = modifier.Add(modValue, modifier.ApplyModifier(baseValue));
            }
        }

        return modValue;
    }

    /// <summary>
    /// Multiplicatively applies every modifier in the list to a given <paramref name="baseValue"/>.
    /// </summary>
    /// <param name="baseValue"></param>
    /// <returns><inheritdoc cref="ApplyModifiersAdditive(T)"/></returns>
    public T ApplyModifiersMultiplicative(T baseValue)
    {
        var modValue = baseValue;

        foreach (var modifier in this)
        {
            if (!modifier.Equals(default))
            {
                modValue = modifier.ApplyModifier(modValue);
            }
        }

        return modValue;
    }
}