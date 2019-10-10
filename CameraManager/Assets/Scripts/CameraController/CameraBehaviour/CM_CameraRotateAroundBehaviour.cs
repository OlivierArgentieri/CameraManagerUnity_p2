using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraRotateAroundBehaviour : CM_CameraBehaviour
{

    #region f/p

    [SerializeField] private float range;
    private float angle;
    #endregion

    #region unity methods

    #endregion

    #region cusom methods

    public override void Init(CM_CameraSettings _settings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init(_settings, _camera, _fAxis);
        OnUpdateBehaviour += RotateAround;
        OnUpdateBehaviour += LookAtTarget;
        name += "[ROTATE AROUND]";
    }

    private void RotateAround()
    { 
        cameraTransform.position = CM_MathTools.RotateAroud(behaviourSettings.CameraTarget.position, behaviourSettings.Distance , ref angle, behaviourSettings.Speed, Time.deltaTime);
    }
    #endregion

}
