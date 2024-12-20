using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceInterfaceAttribute : PropertyAttribute
{
    public readonly System.Type interfaceType;

    public ForceInterfaceAttribute(System.Type type)
    {
        interfaceType = type;
    }
}
