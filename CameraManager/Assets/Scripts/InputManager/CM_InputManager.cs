using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;

namespace InputManager
{
    public class CM_InputManager : MonoBehaviour
    {
        #region f/p

        private static CM_InputManager instance = null;

        public static CM_InputManager Instance => instance;

        public delegate void MouseEventHandler(float _fxValue, float _fyValue, float _fWheelValue);
        public event MouseEventHandler OnMouse;
        
        
        public static event Action<float, float, float> onMouse = null;
        
        #endregion


        #region unity methods

        private void Awake()
        {
            InitSingleton();
        }


        private void Update()
        {
            TriggerMouseEventHandler();
        }

        #endregion


        #region custom methods

        private void InitSingleton()
        {
            if (instance == null)
            {
                instance = this;
                name = "[INPUT MANAGER]";
                DontDestroyOnLoad(this);
            }

            if (instance != this)
            {
                Destroy(gameObject);
                
            }
        }


        private void TriggerMouseEventHandler()
        {
            //onMouse?.Invoke(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
            //OnMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
        }
        #endregion
    }
}