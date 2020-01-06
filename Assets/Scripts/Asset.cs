using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Asset
{
    public static object Load(string path, Type type)
    {
        return Resources.Load(path, type);
    
    }
}
