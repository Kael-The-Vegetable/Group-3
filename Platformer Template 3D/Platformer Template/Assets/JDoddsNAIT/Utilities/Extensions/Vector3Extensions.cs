using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Returns the x and z components of a <see cref="Vector3"/> as a <see cref="Vector2"/>
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 GetHorizontal(this Vector3 v)
    {
        return new(v.x, v.z);
    }

    /// <summary>
    /// Sets the x and z components of a <see cref="Vector3"/> to the x and y values of a given <see cref="Vector2"/>.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="value"></param>
    public static void SetHorizontal(this ref Vector3 v, Vector2 value)
    {
        v.x = value.x;
        v.z = value.y;
    }

    /// <summary>
    /// Returns a copy of the <see cref="Vector3"/> with a y component of 0.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector3 Flatten(this Vector3 v)
    {
        return new(v.x, 0, v.z);
    }
}
