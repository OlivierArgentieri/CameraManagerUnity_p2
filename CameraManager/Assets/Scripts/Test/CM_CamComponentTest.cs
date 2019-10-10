using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CamComponentTest : MonoBehaviour
{
    // Start is called before the first frame update

    private Func<float, IEnumerator> test;
    void Start()
    {
        //InvokeRepeating("LoadGame", 0, 1);
       // yield return StartCoroutine(test(1));
       //yield return StartCoroutine(LoadGame(3));
    }

    
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SetDelay(float _t)
    {
        Debug.Log("LoadGame");
        yield return new WaitForSeconds(_t);
        bool _test = true;
        while (!_test)
        {
            yield return null;
        }
        
        yield break;
        Debug.Log("ok");
        
    }
    
    IEnumerator LoadGame(float _t)
    {
        yield return new WaitForSeconds(_t);
        Debug.Log("test");
    }
    
    void LoadGame()
    {
        Debug.Log("test");
    }

  
}
