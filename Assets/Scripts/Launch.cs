using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
        //canvas.worldCamera
        //canvas.sortingLayerID
        XluaManager.Instance.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
