using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XUUI;

public class HelloWorld : MonoBehaviour
{
    Context context = null;
    public string scriptName = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        XluaManager.Instance.OnInit();

        if (string.IsNullOrEmpty(scriptName))
        {
            Debug.LogErrorFormat("Error HelloWorld args appmodelname is {0} , please input Legal parameters !", scriptName);
            return;
        }
        context = new Context(XluaManager.Instance.GetLoadStringBytesByPath(scriptName), XluaManager.Instance.Env);
        context.Attach(gameObject);
    }

    void OnDestroy()
    {
        context.Dispose();
    }

}
