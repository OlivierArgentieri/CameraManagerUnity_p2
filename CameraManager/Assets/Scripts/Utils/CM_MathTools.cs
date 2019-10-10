using UnityEngine;

public static class CM_MathTools
{
    public static Vector3 Lerp(Vector3 _start, Vector3 _end, float _alpha)
    {
        return (1 - _alpha) * _start + _alpha * _end;
    }
}