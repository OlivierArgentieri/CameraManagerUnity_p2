using System;
using InputManager;
using UnityEngine;

public class CM_InputTest : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private int angle;
    
    private void Awake()
    {
        CM_InputManager.OnVerticalAxis += UpdateMove;
    }
    
    private void OnDestroy()
    {
        CM_InputManager.OnVerticalAxis -= UpdateMove;
    }

    private void Update()
    {
        float y = CM_InputManager.Instance.GetVertical;
        float x = CM_InputManager.Instance.GetHorizontal;
        float ym = CM_InputManager.Instance.GetMouseVertical;
        float xk = CM_InputManager.Instance.GetMouseHorizontal;
        bool j = CM_InputManager.Instance.GetJumpValue;
        bool ju = CM_InputManager.Instance.GetJumpValueUp;
        bool jd = CM_InputManager.Instance.GetJumpValueDown;
    }

    void UpdateMove(float _vertical)
    {
    }
}