using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Camera Manager/Manager")]
public class CM_CameraManager : MonoBehaviour
{
    #region f/p

    private static CM_CameraManager instance = null;
    public static CM_CameraManager Instance => instance;
    private Dictionary<string, CM_CameraComponent> cameras = new Dictionary<string, CM_CameraComponent>();

    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(GetComponent<CM_CameraManager>());
        }
        else
        {
            instance = this;
            name += "[CM_CameraManager]";
            DontDestroyOnLoad(this);
        }
    }

    public void AddCamera(CM_CameraComponent _camera) => CameraManagerHandler(true, _camera);
    public void RemoveCamera(CM_CameraComponent _camera) => CameraManagerHandler(false, _camera);

    void CameraManagerHandler(bool _addCamera, CM_CameraComponent _cameraComponent)
    {
        bool _canUseHanlder = _cameraComponent.IsValid &&
                              (_addCamera
                                  ? !cameras.ContainsKey(_cameraComponent.ID)
                                  : cameras.ContainsKey(_cameraComponent.ID));
        if (!_canUseHanlder)
            throw new CM_CameraManagerMissingComponentException(_cameraComponent, _cameraComponent.name);

        if (_addCamera)
            cameras.Add(_cameraComponent.ID, _cameraComponent);
        else
            cameras.Remove(_cameraComponent.ID);
    }
}