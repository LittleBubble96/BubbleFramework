using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Bubble_NameAttribute))]
public class Bub_NameEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Bubble_NameAttribute a = (Bubble_NameAttribute) attribute;
        label.text = a.Name;
        label.tooltip = a.Describe;
        EditorGUI.PropertyField(position, property, label);
    }
}
