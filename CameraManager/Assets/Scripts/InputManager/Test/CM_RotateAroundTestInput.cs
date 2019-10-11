using System;
using InputManager;
using UnityEngine;

public class CM_RotateAroundTestInput : MonoBehaviour
{
    
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform sourceTransform;
    [SerializeField] private float angle;

    public void Awake()
    {
        CM_InputManager.OnMouse += OnMouseHandle;
    }
    public void OnDestroy()
    {
        CM_InputManager.OnMouse -= OnMouseHandle;
    }

    private void Update()
    {
        this.transform.position = CM_MathTools.RotateAroud(targetTransform.position, 10, angle, 0);
    }

    private void OnMouseHandle(float _vertical, float _horizontal)
    {
        angle += _horizontal;
    }
}