using System.Collections;
using UnityEngine;

public interface IModifier<T>
{
    /// <summary>
    /// The order of this modifier. Lower numbers are applied first.
    /// </summary>
    public int Order => 0;

    /// <summary>
    /// Applies the modifier to the <paramref name="baseValue"/>
    /// </summary>
    /// <param name="baseValue">The base value being modified.</param>
    /// <param name="modValue">The current value before the application of this modifier.</param>
    /// <returns>The modified value.</returns>
    public T ApplyModifier(T baseValue, T modValue);
}
