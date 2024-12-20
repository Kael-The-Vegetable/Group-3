using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Utilities
{
    [System.Serializable]
    public class NameVar<T>
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField, TextArea] public string Description { get; set; }
        [field: SerializeField] public T Value { get; set; }
    }
}