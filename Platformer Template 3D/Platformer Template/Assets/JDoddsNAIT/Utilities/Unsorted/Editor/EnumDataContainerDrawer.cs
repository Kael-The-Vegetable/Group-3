using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using System;
using JDoddsNAIT.Utilities;

namespace JDoddsNAIT.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(EnumDataContainer<,>))]
    public class EnumDataContainerDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty content = property.FindPropertyRelative("content");
            Type enumType = property.GetUnderlyingType().GetGenericArguments()[1];
            float height = EditorGUIUtility.singleLineHeight;

            if (property.isExpanded)
            {
                if (content.arraySize != enumType.GetEnumNames().Length)
                {
                    content.arraySize = enumType.GetEnumNames().Length;
                }

                for (int i = 0; i < content.arraySize; i++)
                {
                    height += EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i)) + EditorGUIUtility.standardVerticalSpacing;
                }
            }
            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty content = property.FindPropertyRelative("content");
            Type enumType = property.GetUnderlyingType().GetGenericArguments()[1];

            EditorGUI.BeginProperty(position, label, property);
            Rect foldoutRect = new(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

            EditorGUI.indentLevel++;
            if (property.isExpanded)
            {
                float addY = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                for (int i = 0; i < content.arraySize; i++)
                {
                    Rect rect = new(position.x, position.y + addY, position.width, EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i), true));
                    addY += rect.height + EditorGUIUtility.standardVerticalSpacing;
                    EditorGUI.PropertyField(rect, content.GetArrayElementAtIndex(i), new GUIContent(enumType.GetEnumNames()[i]), true);
                }
            }
            EditorGUI.indentLevel--;

            EditorGUI.EndProperty();
        }
    }
}