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
    protected Action<MonoBehaviour> onAwake;
    protected Action<MonoBehaviour> onEnable;
    protected Action<MonoBehaviour> onDisable;
    protected Action<MonoBehaviour> onStart;
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
        object[] result = XluaManager.Instance.LuaEnvDoString(string.Format("require('{0}')", luascriptpath));

        if (result == null || result.Length != 1 || !(result[0] is LuaTable))
        {
            throw new Exception("");
        }

        metatable = (LuaTable)result[0];
        //bgn 设置变量
        if (variableArray != null && variableArray.Variables != null)
        {
            foreach (var item in variableArray.Variables)
            {
                var name = item.Name.Trim();
                if (string.IsNullOrEmpty(name)) { continue; }
                metatable.Set(name, variableArray.Get(name));
            }
        }
        //end
        onAwake = metatable.Get<Action<MonoBehaviour>>("awake");
        onEnable = metatable.Get<Action<MonoBehaviour>>("enable");
        onDisable = metatable.Get<Action<MonoBehaviour>>("disable");
        onStart = metatable.Get<Action<MonoBehaviour>>("start");
        onUpdate = metatable.Get<Action<MonoBehaviour>>("update");
        onDestroy = metatable.Get<Action<MonoBehaviour>>("destroy");
    }

    protected override void Awake()
    {
        base.Awake();
        Initialize();
        onAwake?.Invoke(this);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        onEnable?.Invoke(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onDisable?.Invoke(this);
    }

    protected override void Start()
    {
        base.Start();
        onStart?.Invoke(this);
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
        onEnable = null;
        onDisable = null;
        onAwake = null;

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
