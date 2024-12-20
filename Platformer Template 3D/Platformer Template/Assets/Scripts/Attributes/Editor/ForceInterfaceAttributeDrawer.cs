using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ForceInterfaceAttribute))]
public class ForceInterfaceAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            ForceInterfaceAttribute forceInterface = attribute as ForceInterfaceAttribute;
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            var obj = EditorGUI.ObjectField(
                position,
                label,
                property.objectReferenceValue,
                forceInterface.interfaceType,
                !EditorUtility.IsPersistent(property.serializedObject.targetObject));
            if (EditorGUI.EndChangeCheck())
            {
                SetPropertyValue(property, forceInterface, obj);
            }

            EditorGUI.EndProperty();
        }
        else
        {
            EditorGUI.LabelField(position, $"Use {typeof(ForceInterfaceAttribute)} on Object fields.");
        }
    }

    private static void SetPropertyValue(SerializedProperty property, ForceInterfaceAttribute forceInterface, Object obj)
    {
        if (obj != null)
        {
            property.objectReferenceValue = null;
        }
        else if (forceInterface.interfaceType.IsAssignableFrom(obj.GetType()))
        {
            property.objectReferenceValue = obj;
        }
        else if (obj is GameObject)
        {
            var component = (Object)((GameObject)obj).GetComponent(forceInterface.interfaceType);
            if (component != null)
            {
                property.objectReferenceValue = component;
            }
        }
    }
}
