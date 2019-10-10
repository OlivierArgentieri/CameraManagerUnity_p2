using System;
using UnityEngine;

public class CM_CameraBehaviour : MonoBehaviour
{
    #region f/p

    public Action OnUpdateBehaviour = null;
    
    
    protected new Camera camera;
    protected Transform cameraTransform;
    protected CM_CameraSettings behaviourSettings;
    
    private float temp = 0;
    
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
        cameraTransform = _camera.transform;
        behaviourSettings = _settings;
        fAxis = _fAxis;
    }

    protected virtual void FollowTarget()
    {
        
    }

    protected virtual void LookAtTarget()
    {
        if (!IsValid) return;
        Matrix4x4 _oritentation = Matrix4x4.identity;
        Matrix4x4 _translation = Matrix4x4.identity;
        Vector3 _pos = cameraTransform.position;
        Vector3 _target = behaviourSettings.CameraTarget.position;

        Vector3 _zAxis = CM_MathTools.Normalize(CM_MathTools.Substract(_pos, _target));

        Vector3 _xAxis = CM_MathTools.Normalize(CM_MathTools.CrossProduct(Vector3.up, _zAxis));
        Vector3 _yAxis = CM_MathTools.CrossProduct(_zAxis, _xAxis);

        _oritentation = new Matrix4x4(new Vector4(_xAxis.x, _xAxis.y, _xAxis.z, 0),
            new Vector4(_yAxis.x, _yAxis.y, _yAxis.z, 0),
            new Vector4(_zAxis.x, _zAxis.y, _zAxis.z, 0),
            new Vector4(0, 0, 0, 1));

        _translation = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(_pos.x, _pos.y, _pos.z, 1));
        cameraTransform.rotation = (_oritentation * _translation).rotation;
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