using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CamViewTest : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField, Header("CamId Active")]
    private string camId;
    
    private void OnTriggerEnter()
    {
        if(!string.IsNullOrEmpty(camId))
        CM_CameraManager.Instance.SetViewActive(camId);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
