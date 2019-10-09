using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CM_CameraBehaviour : MonoBehaviour
{
    #region f/p

    public Action OnUpdateBehaviour = null;
    
    
    private new Camera camera;
    protected Transform cameraTransform;
    protected CM_CameraSettings behaviourSettings;

    // Accesseur
    public bool IsValid => behaviourSettings.CameraTarget && camera;

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

    public virtual void Init(CM_CameraSettings _settings, Camera _camera, FollowVectorType _fAxis)
    {
        
        if (!_camera) return;
        camera = _camera;
        behaviourSettings = _settings;
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
                return -behaviourSettings.CameraTarget.right;
            case FollowVectorType.Right:
                return behaviourSettings.CameraTarget.right;
            case FollowVectorType.Up:
                return behaviourSettings.CameraTarget.up;
            case FollowVectorType.Down:
                return -behaviourSettings.CameraTarget.up;
            case FollowVectorType.Forward:
                return behaviourSettings.CameraTarget.forward;
            case FollowVectorType.Backward:
                return -behaviourSettings.CameraTarget.forward;
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
        Gizmos.DrawLine(transform.position, behaviourSettings.CameraTarget.position);
    }
    #endregion
}