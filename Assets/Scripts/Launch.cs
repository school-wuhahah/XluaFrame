using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XluaManager.Instance.OnInit();
        App app = gameObject.AddComponent<App>();
        app.appmodelname = "myapp";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
