﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XUUI;

public class App : MonoBehaviour
{
    Context context = null;
    public string appmodelname;

    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(appmodelname))
        {
            Debug.LogErrorFormat("Error App args appmodelname is {0} , please input Legal parameters !", appmodelname);
        }

        context = new Context(string.Format("require('{0}')", appmodelname), XluaManager.Instance.Env);

        context.AddCSharpModule(appmodelname, this);
        context.Attach(gameObject);
    }

    void OnDestroy()
    {
        context.Dispose();
    }

}