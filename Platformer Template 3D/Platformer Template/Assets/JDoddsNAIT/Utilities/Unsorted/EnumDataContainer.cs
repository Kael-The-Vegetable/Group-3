using UnityEngine;
using System;

namespace JDoddsNAIT.Utilities
{
    [Serializable]
    public class EnumDataContainer<TValue, TEnum> where TEnum : Enum
    {
        public TValue[] content = null;
        [HideInInspector] public TEnum[] enumContent = (TEnum[])Enum.GetValues(typeof(TEnum));

        public TValue this[int i]
        {
            get => content[i];
            set => content[i] = value;
        }

        public TValue this[TEnum i]
        {
            get => content[(int)(object)i];
            set => content[(int)(object)i] = value;
        }

        public int Length => content.Length;
    }
}