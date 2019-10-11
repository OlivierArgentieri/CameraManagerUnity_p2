using System;
using UnityEngine;
    public class CM_Test_CM_Vector3 : MonoBehaviour
    {
        [SerializeField] private Vector3 v0 = new Vector3(0,1,0);
        [SerializeField] private Vector3 v1 = new Vector3(1,0,0);
        [SerializeField] private CM_Vector3 v01 = new CM_Vector3(0,1,0);
        [SerializeField] private CM_Vector3 v02 = new CM_Vector3(1,0,0);
        
        
        private void Start()
        {
            Debug.Log(Vector3.Angle(v0,v1));
            Debug.Log(CM_Vector3.Angle(v01, v02));
        }
    }
