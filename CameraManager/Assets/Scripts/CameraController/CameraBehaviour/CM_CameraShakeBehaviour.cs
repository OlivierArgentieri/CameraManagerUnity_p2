using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraShakeBehaviour : CM_CameraBehaviour
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
        OnUpdateBehaviour += Shake;
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

    private void Shake()
    {
        float offset = 1;
        
        float shake = 1;
        
        float _maxYaw= 2;
        float _maxPitch = 1;
        float _maxRoll = 24;

        float yaw = _maxYaw * shake * Mathf.PerlinNoise(Random.seed, Time.time); 
        float pitch = _maxPitch * shake * Mathf.PerlinNoise(Random.seed+1, Time.time); 
        float roll = _maxRoll * shake * Mathf.PerlinNoise(Random.seed+2, Time.time); 
     
        camera.transform.Rotate(roll, pitch, yaw);
            //camera.transform. += new Vector3(offsetX, offsetY, offsetZ);
    }


    #endregion
}
