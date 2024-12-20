using System.Collections;
using UnityEngine;

public interface IModifier<T>
{
    /// <summary>
    /// User-defined method of adding two values of type <typeparamref name="T"/>
    /// </summary>
    /// <remarks>
    /// This method is required because modifiers are applied additively.
    /// </remarks>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public T Add(T a, T b);

    /// <summary>
    /// Applies the modifier to the <paramref name="baseValue"/>
    /// </summary>
    /// <param name="baseValue"></param>
    /// <returns>The modified value.</returns>
    public T ApplyModifier(T baseValue);
}
