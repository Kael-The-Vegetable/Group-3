using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Extensions
{
    public static class EnumExtensions
    {
        public static int ToInt<TValue>(this TValue value) where TValue : Enum
        => (int)(object)value;
    }
}