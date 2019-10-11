using System;
using UnityEngine;

public class CM_TestGenericSingleton<T> : MonoBehaviour
{
    #region f/p
    private static Type instance;
   // public static T Instance => instance;

    
    #endregion


    #region unity methods

    private void Awake()
    {
        
    }

 

    #endregion


    #region custom methods

    private void InitSingleton()
    {
        if (instance == null)
        {
           // instance = Type ;
            
        }
    }

    #endregion
}