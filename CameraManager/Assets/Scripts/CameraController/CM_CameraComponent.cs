using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraComponent : MonoBehaviour
{
    [SerializeField, Header("Camera Component")]
    private string id;
    public string ID => id;

    private new Camera camera;
    public bool IsValid => !string.IsNullOrEmpty(id) && this;

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
    }
    
    void UnRegisterCamera()
    {
        if (!CM_CameraManager.Instance) return;
        CM_CameraManager.Instance.RemoveCamera(this);
    }
}
