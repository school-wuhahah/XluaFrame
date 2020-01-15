using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(Variable))]
public class VariableEditor : PropertyDrawer
{
    private const float HORIZONTAL_GAP = 5;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var name = property.FindPropertyRelative("name");
        var objvalue = property.FindPropertyRelative("objvalue");
        var variableType = property.FindPropertyRelative("variableType");

        float y = position.y;
        float x = position.x;
        float height = GetPropertyHeight(property, label);
        float width = position.width - HORIZONTAL_GAP * 2;

        Rect typeRect = new Rect(x, y, Mathf.Min(120, width * 0.2f), height);
        Rect nameRect = new Rect(typeRect.xMax + HORIZONTAL_GAP, y, Mathf.Min(200, width * 0.4f), height);
        Rect valueRect = new Rect(nameRect.xMax + HORIZONTAL_GAP, y, position.xMax - nameRect.xMax, height);

        EditorGUI.PropertyField(nameRect, name, GUIContent.none);

        VariableType variableTypeValue = (VariableType)variableType.enumValueIndex;
        if (variableTypeValue == VariableType.Component)
        {
            int index = 0;
            List<System.Type> types = new List<System.Type>();
            var component = (Component)objvalue.objectReferenceValue;
            if (component != null)
            {
                GameObject go = component.gameObject;
                foreach (var cmpt in go.GetComponents<Component>())
                {
                    if (!types.Contains(cmpt.GetType()))
                    {
                        types.Add(cmpt.GetType());
                    }
                }

                for (int i = 0; i < types.Count; i++)
                {
                    if (component.GetType().Equals(types[i]))
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (types.Count <= 0)
            {
                types.Add(typeof(Transform));
            }

            List<GUIContent> contents = new List<GUIContent>();
            foreach (var type in types)
            {
                contents.Add(new GUIContent(type.Name, type.FullName));
            }

            EditorGUI.BeginChangeCheck();
            var newIndex = EditorGUI.Popup(typeRect, GUIContent.none, index, contents.ToArray(), EditorStyles.popup);
            if (EditorGUI.EndChangeCheck())
            {
                if (component != null)
                {
                    objvalue.objectReferenceValue = component.gameObject.GetComponent(types[newIndex]);
                }
                else
                {
                    objvalue.objectReferenceValue = null;
                }
            }
        }
        else
        {
            EditorGUI.LabelField(typeRect, variableTypeValue.ToString());
        }

        switch (variableTypeValue)
        {
            case VariableType.Component:
                EditorGUI.BeginChangeCheck();
                objvalue.objectReferenceValue = EditorGUI.ObjectField(valueRect, GUIContent.none, objvalue.objectReferenceValue, typeof(UnityEngine.Component), true);
                if (EditorGUI.EndChangeCheck())
                {
                    if (string.IsNullOrEmpty(name.stringValue) && objvalue.objectReferenceValue != null)
                    {
                        name.stringValue = NormalizeName(objvalue.objectReferenceValue.name);
                    }
                }
                break;
            case VariableType.GameObject:
                EditorGUI.BeginChangeCheck();
                objvalue.objectReferenceValue = EditorGUI.ObjectField(valueRect, GUIContent.none, objvalue.objectReferenceValue, typeof(UnityEngine.GameObject), true);
                if (EditorGUI.EndChangeCheck())
                {
                    if (string.IsNullOrEmpty(name.stringValue) && objvalue.objectReferenceValue != null)
                    {
                        name.stringValue = NormalizeName(objvalue.objectReferenceValue.name);
                    }
                }
                break;
            case VariableType.Object:
                EditorGUI.BeginChangeCheck();
                objvalue.objectReferenceValue = EditorGUI.ObjectField(valueRect, GUIContent.none, objvalue.objectReferenceValue, typeof(UnityEngine.Object), true);
                if (EditorGUI.EndChangeCheck())
                {
                    if (string.IsNullOrEmpty(name.stringValue) && objvalue.objectReferenceValue != null)
                    {
                        name.stringValue = NormalizeName(objvalue.objectReferenceValue.name);
                    }
                }
                break;
            default:
                break;
        }
        EditorGUI.EndProperty();
    }

    private string NormalizeName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return "";

        name = name.Replace(" ", "");
        return char.ToLower(name[0]) + name.Substring(1);
    }
}
