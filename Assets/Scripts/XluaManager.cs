using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XluaManager : MonoSingleton<XluaManager>
{
    private const string luafloder = "LuaScripts";
    private const string luamain = "main";
    private LuaEnv env;

    protected override void Init()
    {
        env = new LuaEnv();
        if (env != null)
        {
            env.AddLoader(LuaScriptsLoader);
        }
    }

    public void OnInit()
    {
        string strcontent = string.Format(string.Format("require('{0}')", luamain));
        LuaEnvDoString(strcontent);       
    }


    private void LuaEnvDoString(string strcontent)
    {
        if (env != null)
        {
            try
            {
                env.DoString(strcontent);
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
        return null;
#endif
    }

    private void Update()
    {
        if (env != null)
        {
            env.Tick();
        }
    }

    public override void Dispose()
    {
        if (env != null)
        {
            try
            {
                env.Dispose();
                env = null;
            }
            catch (Exception ex)
            {
                string msg = string.Format("XluaManager exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }


}
