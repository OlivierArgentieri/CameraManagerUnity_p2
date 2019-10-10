using UnityEngine;

public static class CM_MathTools
{

    public static Vector3 Normalize(Vector3 _v3)
    {
        float _longueur = GetMagnitude(_v3);
        
        float x = _v3.x / _longueur ;
        float y = _v3.y / _longueur ;
        float z = _v3.z / _longueur ;
        
        return new Vector3(x, y, z);
    }
    public static float GetMagnitude(Vector3 _v3)
    {
        float _x = _v3.x;
        float _y = _v3.y;
        float _z = _v3.z;

       return sqrt10(_x * _x + _y *_y + _z*_z);
    }
    public static Vector3 Lerp(Vector3 _start, Vector3 _end, float _alpha)
    {
        return (1 - _alpha) * _start + _alpha * _end;
    }

    public static float sqrt10(float _value)
    {
        float flag = _value / 2;
        for (uint i = 0; i < 10; i++)
        {
            if (flag * flag > _value)
                flag /= 2;
            else
                flag *= 2;
        }
        return flag;
    }

    public static Vector3 Substract(Vector3 _v0, Vector3 _v1)
    {
        float x = _v1.x - _v0.x;
        float y = _v1.y - _v0.y;
        float z = _v1.z - _v0.z;
        
        return new Vector3(x, y, z);
    }

    public static Vector3 CrossProduct(Vector3 _v0, Vector3 _v1)
    {
        float x = (_v0.y * _v1.z) - (_v0.z * _v1.y);
        float y = (_v0.z * _v1.x) - (_v0.x * _v1.z);
        float z = (_v0.x * _v1.y) - (_v0.y * _v1.x);
        
        return new Vector3(x, y, z);
    }

    public static Vector3 RotateAroud(Vector3 _target,float _range, ref float _angle, float _speed, float _t)
    {
        _angle += _t * _speed;
        _angle = (_angle > 359) ? 0 : _angle;

        float _x = Mathf.Cos(_angle) * _range;
        float _y = 0;
        float _z = Mathf.Sin(_angle) * _range;
        return _target + new Vector3(_x, _y, _z);
    }

}