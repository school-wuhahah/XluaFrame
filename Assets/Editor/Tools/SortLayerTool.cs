using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum SortLayerPriority
{
    Default = 0,   //预留 目前没有使用到
    Main = 10,   //主场景层
    MainForSystem = 20,   //主场景层上各种外围系统层级
    MainForFloatBoxTips = 40,   //主场景层上的各种邀请或者浮动界面(跑马灯)
    LowLoadingCommonMessageBoxTips0 = 50, //游戏中各种通用弹框（低于loading页面）
    Loading0 = 60, //各种loading页面层级
    UpLoadingCommonMessageBoxTips0 = 70, //游戏中各种通用弹框层级（高于loading页面）
    NewPlayerGuide0 = 80, //游戏中新手指引层级
    SystemBoxTips0 = 90, //系统弹框
    //Count = 100
};

public class SortLayerTool
{
    [MenuItem("Tools/SortingLayer")]
    public static void AddSortingLayer()
    {
        // 先遍历枚举拿到枚举的字符串
        List<string> lstSceenPriority = new List<string>();
        foreach (int v in Enum.GetValues(typeof(SortLayerPriority)))
        {
            lstSceenPriority.Add(Enum.GetName(typeof(SortLayerPriority), v));
        }

        // 清除数据
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        if (tagManager == null)
        {
            Debug.LogError("未能序列化tagManager！！！！！！");
            return;
        }
        SerializedProperty it = tagManager.GetIterator();
        while (it.NextVisible(true))
        {
            if (it.name != "m_SortingLayers")
            {
                continue;
            }
            // 先删除所有
            while (it.arraySize > 0)
            {
                it.DeleteArrayElementAtIndex(0);
            }

            // 重新插入
            // 将枚举字符串生成到 sortingLayer
            foreach (var s in lstSceenPriority)
            {
                it.InsertArrayElementAtIndex(it.arraySize);
                SerializedProperty dataPoint = it.GetArrayElementAtIndex(it.arraySize - 1);

                while (dataPoint.NextVisible(true))
                {
                    if (dataPoint.name == "name")
                    {
                        dataPoint.stringValue = s;
                    }
                    else if (dataPoint.name == "uniqueID")
                    {
                        dataPoint.intValue = (int)Enum.Parse(typeof(SortLayerPriority), s);
                    }
                }
            }
        }
        tagManager.ApplyModifiedProperties();
        AssetDatabase.SaveAssets();
    }

    public static bool IsHaveSortingLayer(string sortingLayer)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/Tagmanager.asset")[0]);
        if (tagManager == null)
        {
            Debug.LogError("未能序列化tagManager！！！！！！ IsHaveSortingLayer");
            return true;
        }
        SerializedProperty it = tagManager.GetIterator();
        while (it.NextVisible(true))
        {
            if (it.name != "m_SortingLayers")
            {
                continue;
            }
            for (int i = 0; i < it.arraySize; i++)
            {
                SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                while (dataPoint.NextVisible(true))
                {
                    if (dataPoint.name != "name")
                    {
                        continue;
                    }
                    if (dataPoint.stringValue == sortingLayer)
                    {
                        return true;
                    }
                }
            }
        }


        return false;
    }

}
