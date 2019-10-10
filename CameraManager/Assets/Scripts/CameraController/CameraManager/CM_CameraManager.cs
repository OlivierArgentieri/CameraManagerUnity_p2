using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Camera Manager/Manager")]
public class CM_CameraManager : MonoBehaviour
{
    #region f/p

    private static CM_CameraManager instance = null;
    public static CM_CameraManager Instance => instance;
    private Dictionary<string, CM_CameraComponent> cameras = new Dictionary<string, CM_CameraComponent>();

    [SerializeField, Header("Focus Camera")]
    private string CameraFocusId;
    #endregion

    #region unity methods
    private void Awake()
    {
        InitSingleton();
    }

    private void LateUpdate() => UpdateCameraComponent();
    #endregion

    #region custom methods

    void UpdateCameraComponent()
    {
        foreach (KeyValuePair<string, CM_CameraComponent> cam in cameras.Where(c => c.Value.IsEnable))
        {
            cam.Value.CameraBehaviour.OnUpdateBehaviour?.Invoke();
        }
    }

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
            name = "[CM_CameraManager]";
            DontDestroyOnLoad(gameObject);
        }
        
        if (instance != this)
            Destroy(gameObject);
    }
    
    public void AddCamera(CM_CameraComponent _camera) => CameraManagerHandler(true, _camera);
    public void RemoveCamera(CM_CameraComponent _camera) => CameraManagerHandler(false, _camera);

    void CameraManagerHandler(bool _addCamera, CM_CameraComponent _cameraComponent)
    {
        bool _canUseHandler = _cameraComponent.IsValid &&
                              (_addCamera
                                  ? !cameras.ContainsKey(_cameraComponent.ID)
                                  : cameras.ContainsKey(_cameraComponent.ID));
        if (!_canUseHandler)
            throw new CM_CameraManagerMissingComponentException(_cameraComponent, _cameraComponent.name);

        if (_addCamera)
            cameras.Add(_cameraComponent.ID, _cameraComponent);
        else
            cameras.Remove(_cameraComponent.ID);
    }

    public void DisableCamera(CM_CameraComponent _cameraComponent)
    {
        if (!cameras.ContainsKey(_cameraComponent.ID)) return;
        _cameraComponent.IsEnable = false;
    }
    
    public void DisableCamera(string _cameraComponentId)
    {        
        if (!cameras.ContainsKey( _cameraComponentId)) return;
        cameras[ _cameraComponentId].IsEnable = false;

    }
    
    public void EnableCamera(CM_CameraComponent _cameraComponent)
    {
        if (!cameras.ContainsKey(_cameraComponent.ID)) return;
        _cameraComponent.IsEnable = true;
    }
    
    public void EnableCamera(string _cameraComponentId)
    {
        if (!cameras.ContainsKey( _cameraComponentId)) return;
        cameras[ _cameraComponentId].IsEnable = true;
    }
    #endregion
    
    #region debug

    [SerializeField, Range(.1f, 1f), Header("DEBUG - GIZMO SIZE")]
    private float size = 1;
    private void OnDrawGizmos()
    {
        DrawnSphereOnManager();
        Gizmos.color = Color.yellow;
        foreach (KeyValuePair<string, CM_CameraComponent> cam in cameras)
        {
            Gizmos.DrawLine(transform.position, cam.Value.transform.position);
        }
        Gizmos.color = Color.white;
    }

    private void DrawnSphereOnManager()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 2, size);
        Gizmos.color = Color.white;

    }

    public void SetViewActive(string _camID)
    {
        if (!cameras.ContainsKey((_camID))) return;
        cameras.Values.ToList().ForEach(o => o.SetViewActive(false));
        cameras[_camID].SetViewActive(true);
    }

    private void DisableAllCamera()
    {
        cameras.Values.ToList().ForEach(o => DisableCamera(o));
    }

    private void SwitchCamera(string _cameraId)
    {
        DisableAllCamera();
        EnableCamera(_cameraId);
    }
    
    
    #endregion
}