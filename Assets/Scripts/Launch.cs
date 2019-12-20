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
        App testmyapp = gameObject.AddComponent<App>();
        testmyapp.appmodelname = @"testmyapp";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
