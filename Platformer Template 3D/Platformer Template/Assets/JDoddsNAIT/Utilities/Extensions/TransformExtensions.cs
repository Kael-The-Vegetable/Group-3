using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Extensions
{
    public static class TransformExtensions
    {
        //Scale by multiplying
        /// <summary>
        /// Multiplies a <see cref="Transform"/>'s localScale by the given <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/> values.
        /// </summary>
        public static void Scale(this Transform transform, float x, float y, float z)
        {
            transform.localScale = new Vector3(
                transform.localScale.x * x,
                transform.localScale.y * y,
                transform.localScale.z * z);
        }

        /// <summary>
        /// Multiplies a <see cref="Transform"/>'s localScale by <paramref name="amount"/>.
        /// </summary>
        public static void Scale(this Transform transform, Vector3 amount) => transform.Scale(amount.x, amount.y, amount.z);

        /// <summary>
        /// Multiplies a <see cref="Transform"/>'s localScale by <paramref name="amount"/>.
        /// </summary>
        public static void Scale(this Transform transform, float amount) => transform.Scale(amount, amount, amount);

        // Scale ay addition
        /// <summary>
        /// Adds <paramref name="amount"/> to a <see cref="Transform"/>'s localScale.
        /// </summary>
        public static void ScaleBy(this Transform transform, Vector3 amount) => transform.localScale += amount;

        /// <summary>
        /// Adds the given <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/> values to a <see cref="Transform"/>'s localScale.
        /// </summary>
        public static void ScaleBy(this Transform transform, float x, float y, float z) => transform.ScaleBy(new Vector3(x, y, z));

        /// <summary>
        /// Adds <paramref name="amount"/> to a <see cref="Transform"/>'s localScale.
        /// </summary>
        public static void ScaleBy(this Transform transform, float amount) => transform.ScaleBy(new Vector3(amount, amount, amount));
    }
}