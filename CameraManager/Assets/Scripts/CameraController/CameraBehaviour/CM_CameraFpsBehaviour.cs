using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraFpsBehaviour : CM_CameraBehaviour
{
    #region unity methods
    #endregion
    
    #region custom methods

    public override void Init(CM_CameraSettings _settings, Camera _camera, FollowVectorType _fAxis)
    {
        base.Init( _settings, _camera, _fAxis);
        debugColor = Color.green;
        OnUpdateBehaviour += FollowTarget;
        OnUpdateBehaviour += LookAtTarget;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void FollowTarget()
    {
        base.FollowTarget();
    }

    protected override void LookAtTarget()
    {
        base.LookAtTarget();
    }
    
    #endregion
}
