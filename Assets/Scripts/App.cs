using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using XUUI;

public class App : MonoBehaviour
{
    Context context = null;
    public string appmodelname;

    public void RunApp()
    {
        if (string.IsNullOrEmpty(appmodelname))
        {
            Debug.LogErrorFormat("Error App args appmodelname is {0} , please input Legal parameters !", appmodelname);
        }

        context = new Context(XluaManager.Instance.GetLoadStringBytesByPath(appmodelname), XluaManager.Instance.Env);
        context.AddCSharpModule(appmodelname, this);
        context.Attach(gameObject);
    }

    void OnDestroy()
    {
        context.Dispose();
    }

}
