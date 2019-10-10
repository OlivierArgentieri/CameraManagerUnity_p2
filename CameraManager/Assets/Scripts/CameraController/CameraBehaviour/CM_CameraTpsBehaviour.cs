using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InputManager;
using UnityEngine;
using Object = System.Object;

public class CM_CameraTpsBehaviour : CM_CameraBehaviour
{
    #region f/p

    private Vector2 input;
    
    #endregion

    #region unity methods

    private void Start()
    {
        //FindObjectsOfType<UnityEngine.Object>().ToList().ForEach( o => Destroy(o));
        CM_InputManager.Instance.OnMouse += InputManagerOnMouse;
    }

    #endregion

    #region custom methods

    public override void Init(CM_CameraSettings _settings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init(_settings, _camera, _fAxis);
        debugColor = Color.green;
        OnUpdateBehaviour += FollowTarget;
        OnUpdateBehaviour += LookAtTarget;
    }

    private void InputManagerOnMouse(float _fxValue, float _fyValue, float _fWheelValue)
    {
        input += new Vector2(_fxValue * behaviourSettings.Speed * Time.deltaTime, _fyValue * behaviourSettings.Speed * Time.deltaTime);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void FollowTarget()
    {
        if (!IsValid) return;
        
        Vector3 offset = GetFollowAxis() * behaviourSettings.Distance;
        camera.transform.position = CM_MathTools.Lerp(camera.transform.position, behaviourSettings.CameraTarget.position + offset, /*Time.deltaTime * behaviourSettings.Speed*/ 0.5f);
        
    }

    protected override void LookAtTarget()
    {
        //camera.transform.forward = behaviourSettings.CameraTarget.position - camera.transform.position;
        //transform.localRotation = Quaternion.Euler(input.y, input.x, 0);
       // transform.localPosition = behaviourSettings.CameraTarget.transform.position - (transform.localRotation * Vector3.forward * behaviourSettings.Distance);
        base.LookAtTarget();
    }

    #endregion
}