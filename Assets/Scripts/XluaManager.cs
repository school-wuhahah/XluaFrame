﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XluaManager : MonoSingleton<XluaManager>
{
    private const string luafloder = "LuaScripts";
    private const string luamain = "main";

    public LuaEnv Env { get; private set; }

    protected override void Init()
    {
        Env = new LuaEnv();
        if (Env != null)
        {
            Env.AddLoader(LuaScriptsLoader);
        }
    }

    public void OnInit()
    {
        string strcontent = string.Format("require('{0}')", luamain);
        LuaEnvDoString(strcontent);       
    }


    private void LuaEnvDoString(string strcontent)
    {
        if (Env != null)
        {
            try
            {
                Env.DoString(strcontent);
            }
            catch (Exception ex)
            {
                string msg = string.Format("XluaManager exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }

    private byte[] LuaScriptsLoader(ref string filepath)
    {
        filepath = filepath.Replace(".", "/") + ".lua";
#if UNITY_EDITOR
        filepath = Path.Combine(Application.dataPath, luafloder, filepath);
        return FileOperate.ReadFileBytes(filepath);
#endif
    }

    private void Update()
    {
        if (Env != null)
        {
            Env.Tick();
        }
    }

    public override void Dispose()
    {
        if (Env != null)
        {
            try
            {
                Env.Dispose();
                Env = null;
            }
            catch (Exception ex)
            {
                string msg = string.Format("XluaManager exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }


}
