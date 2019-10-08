using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraBehaviour : MonoBehaviour
{
    #region f/p

    public Action OnUpdateBehaviour = null;
    
    
    private new Camera camera;
    protected Transform cameraTransform;

    [SerializeField, Header("Camera Speed"), UnityEngine.Range(-10, 10)]
    protected float speed = 1;

    [SerializeField, Header("Camera distance"), UnityEngine.Range(.1f, 100f)]
    protected float distance = 0;

    [SerializeField, Header("Camera target")]
    protected Transform cameraTarget;

    // Accesseur
    public bool IsValid => cameraTarget && camera;

    // 
    public enum FollowVectorType
    {
        Left,
        Right,
        Up,
        Down,
        Forward,
        Backward
    }

    [SerializeField, Header("Camera vector type")]
    private FollowVectorType fAxis;

    #endregion

    #region unity methods
    protected virtual void OnDestroy()
    {
        OnUpdateBehaviour = null;
    }
    
    #endregion

    #region custom methods

    public virtual void Init(Transform _target, Camera _camera, FollowVectorType _fAxis)
    {
        if (!_camera) return;
        camera = _camera;
        cameraTransform = _camera.transform;
        cameraTarget = _target;
        fAxis = _fAxis;
    }

    protected virtual void FollowTarget()
    {
    }

    protected virtual void LookAtTarget()
    {
    }

    protected Vector3 GetFollowAxis()
    {
        switch (fAxis)
        {
            case FollowVectorType.Left:
                return -cameraTarget.right;
            case FollowVectorType.Right:
                return cameraTarget.right;
            case FollowVectorType.Up:
                return cameraTarget.up;
            case FollowVectorType.Down:
                return -cameraTarget.up;
            case FollowVectorType.Forward:
                return cameraTarget.forward;
            case FollowVectorType.Backward:
                return -cameraTarget.forward;
        }

        return Vector3.zero;
    }
    #endregion
    
    #region debug

    protected Color debugColor = Color.white;

    [SerializeField, Range(.1f, 1f), Header("DEBUG - GIZMO SIZE")]
    private float size = 1;

    private void OnDrawGizmos()
    {
        if (!IsValid) return;
        Gizmos.color = debugColor;
        Gizmos.DrawSphere(transform.position + Vector3.up *2, size);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, cameraTarget.position);
    }
    #endregion
}