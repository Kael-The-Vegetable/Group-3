using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace JDoddsNAIT.ObjectDetection.Editor
{
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagFieldAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "Use TagField on string types.", MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            if (string.IsNullOrEmpty(property.stringValue))
            {
                property.stringValue = "Untagged";
            }

            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);

            EditorGUI.EndProperty();
        }
    }
}