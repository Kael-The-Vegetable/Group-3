using JDoddsNAIT.Utilities;
using UnityEditor;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(EventVar<>))]
    public class EventVarDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty value = property.FindPropertyRelative("_value");
            SerializedProperty onValueChanged = property.FindPropertyRelative("_onValueChanged");

            float height = EditorGUI.GetPropertyHeight(value, label, true);
            if (property.isExpanded)
            {
                height += EditorGUI.GetPropertyHeight(onValueChanged, true) + EditorGUIUtility.standardVerticalSpacing;
            }
            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty value = property.FindPropertyRelative("_value");
            SerializedProperty onValueChanged = property.FindPropertyRelative("_onValueChanged");

            float foldoutButtonWidth = 14f;

            EditorGUI.BeginProperty(position, label, property);
            Rect valueRect = new(position.x + foldoutButtonWidth, position.y, position.width - foldoutButtonWidth, EditorGUI.GetPropertyHeight(value, true));
            Rect foldoutRect = new(position.x, position.y, EditorGUIUtility.labelWidth, valueRect.height);
            Rect eventRect = new(position.x, position.y + EditorGUIUtility.standardVerticalSpacing + valueRect.height, position.width, EditorGUI.GetPropertyHeight(onValueChanged, true));

            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, GUIContent.none);
            EditorGUIUtility.labelWidth -= foldoutButtonWidth;
            EditorGUI.PropertyField(valueRect, value, new GUIContent(property.displayName), true);
            EditorGUIUtility.labelWidth += foldoutButtonWidth;

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUI.PropertyField(eventRect, onValueChanged, true);
                EditorGUI.indentLevel--;
            }
            EditorGUI.EndProperty();
        }
    }
}