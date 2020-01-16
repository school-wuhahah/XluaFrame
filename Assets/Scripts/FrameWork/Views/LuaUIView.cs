using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;
using UnityEngine.EventSystems;

public class LuaUIView : UIBehaviour
{
    public string luascriptpath;
    public VariableArray variableArray;

    protected LuaTable scriptEnv;
    protected LuaTable metatable;

    protected Action<MonoBehaviour> onStart;
    protected Action<MonoBehaviour> onDisable;
    protected Action<MonoBehaviour> onUpdate;
    protected Action<MonoBehaviour> onDestroy;

    protected virtual void Initialize()
    {
        var luaEnv = XluaManager.Instance.Env;
        scriptEnv = luaEnv.NewTable();

        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("target", this);

        if (string.IsNullOrEmpty(luascriptpath))
        {
            Debug.LogError("luascriptpath is null or Empty ... ");
        }
        string scriptText = string.Format("require(\"common.oop.system\");local cls = require(\"{0}\");return extends(target,cls);", luascriptpath);
        object[] result = XluaManager.Instance.LuaEnvDoString(scriptText, string.Format("{0}({1})", "LuaUIView", this.name), scriptEnv);

        if (result == null || result.Length != 1 || !(result[0] is LuaTable))
        {
            throw new Exception("");
        }

        metatable = (LuaTable)result[0];
        if (variableArray != null && variableArray.Variables != null)
        {
            foreach (var item in variableArray.Variables)
            {
                var name = item.Name.Trim();
                if (string.IsNullOrEmpty(name)) { continue; }
                metatable.Set(name, variableArray.Get(name));
            }
        }

        onDisable = metatable.Get<Action<MonoBehaviour>>("disable");
        onStart = metatable.Get<Action<MonoBehaviour>>("start");
        onUpdate = metatable.Get<Action<MonoBehaviour>>("update");
        onDestroy = metatable.Get<Action<MonoBehaviour>>("destroy");
    }

    protected override void Start()
    {
        base.Start();
        Initialize();
        onStart?.Invoke(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onDisable?.Invoke(this);
    }

    protected virtual void Update()
    {
        onUpdate?.Invoke(this);
    }

    protected override void OnDestroy()
    {
        onDestroy?.Invoke(this);
        onDestroy = null;
        onUpdate = null;
        onStart = null;
        onDisable = null;

        if (metatable != null)
        {
            metatable.Dispose();
            metatable = null;
        }

        if (scriptEnv != null)
        {
            scriptEnv.Dispose();
            scriptEnv = null;
        }

        base.OnDestroy();
    }
}
