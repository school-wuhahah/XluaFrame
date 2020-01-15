using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

[CustomPropertyDrawer(typeof(VariableArray))]
public class VariableArrayEditor : PropertyDrawer
{
    private const float HORIZONTAL_GAP = 5;
    private const float VERTICAL_GAP = 5;

    private ReorderableList list;

    private ReorderableList GetList(SerializedProperty property)
    {
        if (list == null)
        {
            list = new ReorderableList(property.serializedObject, property, true, true, true, true)
            {
                elementHeight = 22,
                drawElementCallback = DrawElement,
                drawHeaderCallback = DrawHeader,
                onAddDropdownCallback = OnAddElement,
                onRemoveCallback = OnRemoveElement,
                drawElementBackgroundCallback = DrawElementBackground
            };
        }
        else
        {
            list.serializedProperty = property;
        }
        return list;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var list = GetList(property.FindPropertyRelative("variables"));
        list.DoList(position);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = base.GetPropertyHeight(property, label) + 60;
        var variables = property.FindPropertyRelative("variables");
        for (int i = 0; i < variables.arraySize; i++)
            height += EditorGUI.GetPropertyHeight(variables.GetArrayElementAtIndex(i)) + VERTICAL_GAP;
        return height;
    }


    private void OnAddElement(Rect buttonRect, ReorderableList list)
    {
        var variables = list.serializedProperty;
        int index = variables.arraySize > 0 ? variables.arraySize : 0;
        this.DrawContextMenu(variables, index);
    }

    private void DrawContextMenu(SerializedProperty variables, int index)
    {
        GenericMenu menu = new GenericMenu();
        foreach (VariableType variableType in System.Enum.GetValues(typeof(VariableType)))
        {
            var type = variableType;
            menu.AddItem(new GUIContent(type.ToString()), false, content =>
            {
                AddVariable(variables, index, type);
            }, null);
        }
        menu.ShowAsContext();
    }

    protected virtual void AddVariable(SerializedProperty variables, int index, VariableType type)
    {
        if (index < 0 || index > variables.arraySize)
            return;

        variables.serializedObject.Update();
        variables.InsertArrayElementAtIndex(index);
        SerializedProperty variableProperty = variables.GetArrayElementAtIndex(index);

        variableProperty.FindPropertyRelative("variableType").enumValueIndex = (int)type;
        variableProperty.FindPropertyRelative("name").stringValue = "";
        variableProperty.FindPropertyRelative("objvalue").objectReferenceValue = null;

        variables.serializedObject.ApplyModifiedProperties();
        GUI.FocusControl(null);
    }


    private void DrawElementBackground(Rect rect, int index, bool isActive, bool isFocused)
    {
        ReorderableList.defaultBehaviours.DrawElementBackground(rect, index, isActive, false, true);
    }

    private void OnRemoveElement(ReorderableList list)
    {
        var variables = list.serializedProperty;
        AskRemoveVariable(variables, list.index);
    }



    private void DrawHeader(Rect rect)
    {
        GUI.Label(rect, "Variables");
    }

    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        var variables = list.serializedProperty;
        if (index < 0 || index >= variables.arraySize)
            return;

        var variable = variables.GetArrayElementAtIndex(index);

        float x = rect.x;
        float y = rect.y + 2;
        float width = rect.width - 40;
        float height = rect.height;

        Rect variableRect = new Rect(x, y, width, height);
        EditorGUI.PropertyField(variableRect, variable, GUIContent.none);

        var buttonLeftRect = new Rect(variableRect.xMax + HORIZONTAL_GAP, y - 2, 18, 18);
        var buttonRightRect = new Rect(buttonLeftRect.xMax, y - 2, 18, 18);

        if (GUI.Button(buttonLeftRect, new GUIContent("+"), EditorStyles.miniButtonLeft))
        {
            DuplicateVariable(variables, index);
        }
        if (GUI.Button(buttonRightRect, new GUIContent("-"), EditorStyles.miniButtonRight))
        {
            AskRemoveVariable(variables, index);
        }
    }

    protected virtual void DuplicateVariable(SerializedProperty variables, int index)
    {
        if (index < 0 || index >= variables.arraySize)
            return;

        variables.serializedObject.Update();
        variables.InsertArrayElementAtIndex(index);
        SerializedProperty variableProperty = variables.GetArrayElementAtIndex(index + 1);

        variableProperty.FindPropertyRelative("name").stringValue = "";
        variableProperty.FindPropertyRelative("objvalue").objectReferenceValue = null;

        variables.serializedObject.ApplyModifiedProperties();
        GUI.FocusControl(null);
    }

    protected virtual void AskRemoveVariable(SerializedProperty variables, int index)
    {
        if (variables == null || index < 0 || index >= variables.arraySize)
            return;

        var variable = variables.GetArrayElementAtIndex(index);
        var name = variable.FindPropertyRelative("name").stringValue;
        if (string.IsNullOrEmpty(name))
        {
            RemoveVariable(variables, index);
            return;
        }

        if (EditorUtility.DisplayDialog("Confirm delete", string.Format("Are you sure you want to delete the item named \"{0}\"?", name), "Yes", "Cancel"))
        {
            RemoveVariable(variables, index);
        }
    }

    protected virtual void RemoveVariable(SerializedProperty variables, int index)
    {
        if (index < 0 || index >= variables.arraySize)
            return;

        variables.serializedObject.Update();
        variables.DeleteArrayElementAtIndex(index);
        variables.serializedObject.ApplyModifiedProperties();
        GUI.FocusControl(null);
    }
}
