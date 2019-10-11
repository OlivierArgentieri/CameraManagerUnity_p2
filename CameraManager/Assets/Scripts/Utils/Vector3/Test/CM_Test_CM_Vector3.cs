using System;
using UnityEngine;
    public class CM_Test_CM_Vector3 : MonoBehaviour
    {
        [SerializeField] private Vector3 v0 = new Vector3(10,10,20);
        [SerializeField] private CM_Vector3 v1 = new CM_Vector3(10,10,20);
        
        
        private void Start()
        {
            Debug.Log(v0);
            Debug.Log(v1[0]);
            
        }
    }
