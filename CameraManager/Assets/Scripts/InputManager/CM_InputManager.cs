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

#if UNITY_EDITOR
        [SerializeField, Header("Debug Gizmos Size"), UnityEngine.Range(0, 10)]
        private float size;

        [SerializeField, Header("Debug Gizmos Size")]
        private Color gizmosColor;

        [SerializeField, Header("Debug Gizmos Size"), UnityEngine.Range(0, 10)]
        private float height;
#endif

        #endregion

        #region input axis

        // Vertical Keyboard
        [SerializeField, Header("Vertical Axis")]
        private string vAxis = "Vertical";

        [SerializeField, Header("Feedback vAxis"), Range(-1, 1)]
        private float vAxisValue;


        // Horizontal Keyboard
        [SerializeField, Header("Horizontal Axis")]
        private string hAxis = "Horizontal";

        [SerializeField, Header("Feedback hAxis"), Range(-1, 1)]
        private float hAxisValue;


        // Mouse Axis Y
        [SerializeField, Header("Mouse Vertical Axis")]
        private string yMouse = "Mouse Y";

        [SerializeField, Header("Feedback VerticalMouseAxis"), Range(-1, 1)]
        private float yMouseAxisValue;

        // Mouse Axis X
        [SerializeField, Header("Mouse Vertical Axis")]
        private string xMouse = "Mouse X";

        [SerializeField, Header("Feedback HorizontalMouseAxis"), Range(-1, 1)]
        private float xMouseAxisValue;


        public float GetVertical => vAxisValue = Input.GetAxis(vAxis);
        public float GetHorizontal => hAxisValue = Input.GetAxis(hAxis);
        public float GetMouseVertical => yMouseAxisValue = Input.GetAxis(yMouse);
        public float GetMouseHorizontal => xMouseAxisValue = Input.GetAxis(xMouse);

        #endregion

        #region input

        [SerializeField, Header("Jump Input")] private KeyCode jumpValue = KeyCode.Space;

        [SerializeField, Header("Jump Feedback")]
        private bool jumpPressed;

        [SerializeField, Header("JumpUp Feedback")]
        private bool jumpPressedUp;

        [SerializeField, Header("JumpDown Feedback")]
        private bool jumpPressedDown;

        public bool GetJumpValue => jumpPressed = Input.GetKey(jumpValue);
        public bool GetJumpValueUp => jumpPressedUp = Input.GetKeyUp(jumpValue);
        public bool GetJumpValueDown => jumpPressedDown = Input.GetKeyDown(jumpValue);

        #endregion

        #region event

        public static event Action<float> OnVerticalAxis = null;

        #endregion


        #region unity methods

        private void Awake()
        {
            InitSingleton();
        }


        private void Update()
        {
            //OnVerticalAxis.Invoke(GetVertical);
            OnVerticalAxis?.Invoke(GetVertical);
        }

        #endregion


        #region custom methods

        private void InitSingleton()
        {
            if (instance == null)
            {
                instance = this;
                name = "[CM_INPUT_MANAGER]";
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


#if UNITY_EDITOR

        #region debug

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;

            Gizmos.DrawSphere(transform.position + Vector3.up * height, size);
        }

        #endregion

#endif
    }
}