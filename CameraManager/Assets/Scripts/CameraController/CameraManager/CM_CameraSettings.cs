using System;
using UnityEngine;

[Serializable]
public class CM_CameraSettings
{
    [SerializeField, Header("Camera Speed"), UnityEngine.Range(.1f, 100)]
    protected float speed = 1;

    public float Speed => speed;


    [SerializeField, Header("Camera distance"), UnityEngine.Range(.1f, 100f)]
    protected float distance = 0;

    public float Distance => distance;

    [SerializeField, Header("Camera target")]
    protected Transform cameraTarget;

    public Transform CameraTarget => cameraTarget;
}