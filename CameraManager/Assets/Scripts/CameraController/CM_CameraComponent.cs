using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Camera Manager/Component")]
public class CM_CameraComponent : MonoBehaviour
{
    [SerializeField, Header("Camera Component")]
    private string id = "id";
    public string ID => id;

    [SerializeField, Header("Camera Type")]
    private CM_CameraType type = CM_CameraType.TPS;
    
    [SerializeField, Header("Camera Settings")]
    private CM_CameraSettings camSettings;
    
    private CM_CameraBehaviour cameraBehaviour;

    public CM_CameraBehaviour CameraBehaviour
    {
        get
        {
            if (!cameraBehaviour) throw new  CM_CameraManagerMissingBehaviourException(gameObject.name);
            return cameraBehaviour;
        }
    }
    
    private new Camera camera;
    public bool IsValid => !string.IsNullOrEmpty(id) && this;
    public bool IsEnable { get; set; } = true;

    private void Start() => RegisterCamera();

    private void OnDestroy() => UnRegisterCamera();

    void RegisterCamera()
    {
       if (!CM_CameraManager.Instance) return;

        if (!camera)
        {
            camera = GetComponent<Camera>();
            if (!camera) throw new CM_CameraManagerMissingCameraException(gameObject.name);
        }
        CM_CameraManager.Instance.AddCamera(this);
        name += "[CM]";
        InitBehaviour();
    }
    
    void UnRegisterCamera()
    {
        if (!CM_CameraManager.Instance) return;
        CM_CameraManager.Instance.RemoveCamera(this);
    }

    void InitBehaviour()
    {
        CM_CameraBehaviour.FollowVectorType _fAxis = CM_CameraBehaviour.FollowVectorType.Up;
        switch (type)
        {
            case CM_CameraType.RTS:
                break;
            case CM_CameraType.TPS:
                cameraBehaviour = gameObject.AddComponent<CM_CameraTpsBehaviour>();
                _fAxis = CM_CameraBehaviour.FollowVectorType.Backward;
                break;
            case CM_CameraType.FPS:
               
                break;
            case CM_CameraType.ROTATE_AROUND:
                cameraBehaviour = gameObject.AddComponent<CM_CameraRotateAroundBehaviour>();
                _fAxis = CM_CameraBehaviour.FollowVectorType.Backward;
                break;

            case CM_CameraType.OSCILLATION:
                cameraBehaviour = gameObject.AddComponent<CM_CameraOscillationBehaviour>();
                _fAxis = CM_CameraBehaviour.FollowVectorType.Backward;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        if(cameraBehaviour)
            cameraBehaviour.Init(camSettings, camera, _fAxis);
    }
}

public enum CM_CameraType
{
    RTS,
    TPS,
    FPS,
    ROTATE_AROUND,
    OSCILLATION
}



