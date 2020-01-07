using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XluaManager.Instance.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
