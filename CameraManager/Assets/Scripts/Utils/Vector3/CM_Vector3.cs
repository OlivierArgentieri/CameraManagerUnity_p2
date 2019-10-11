using System;
[Serializable]
public struct CM_Vector3
{
    #region f/p

    public float x;
    public float y;
    public float z;

    // static propertites
    private static CM_Vector3 zero = new CM_Vector3(0, 0, 0);
    private static CM_Vector3 one = new CM_Vector3(1, 1, 1);
    private static CM_Vector3 up = new CM_Vector3(0, 1, 0);
    private static CM_Vector3 down = new CM_Vector3(0, -1, 0);
    private static CM_Vector3 right = new CM_Vector3(1, 0, 0);
    private static CM_Vector3 left= new CM_Vector3(-1, 0, 0);
    private static CM_Vector3 back= new CM_Vector3(0, 0, -1);
    private static CM_Vector3 forward = new CM_Vector3(0, 0, 1);

    #endregion
    
    public CM_Vector3(float _x, float _y, float _z)
    {
        this.x = _x;
        this.y = _y;
        this.z = _z;
    }

    public bool Equals(CM_Vector3 other)
    {
        return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
    }
    
    

    public override bool Equals(object obj)
    {
        return obj is CM_Vector3 other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = x.GetHashCode();
            hashCode = (hashCode * 397) ^ y.GetHashCode();
            hashCode = (hashCode * 397) ^ z.GetHashCode();
            return hashCode;
        }
    }

    public static CM_Vector3 operator -(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        return new CM_Vector3(_v0.x - _v1.x, _v0.y - _v1.y, _v0.z - _v1.z);
    }

    public static CM_Vector3 operator +(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        return new CM_Vector3(_v0.x + _v1.x, _v0.y + _v1.y, _v0.z + _v1.z);
    }

    public static CM_Vector3 operator *(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        return new CM_Vector3(_v0.x * _v1.x, _v0.y * _v1.y, _v0.z * _v1.z);
    }
    public static CM_Vector3 operator *(CM_Vector3 _v0, float _f0)
    {
        return new CM_Vector3(_v0.x * _f0, _v0.y * _f0, _v0.z * _f0);
    }

    public static CM_Vector3 operator /(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        if (_v1.x == 0 || _v1.y == 0 || _v1.z == 0) throw new Exception("Divide by zero !!!");
        return new CM_Vector3(_v0.x / _v1.x, _v0.y / _v1.y, _v0.z / _v1.z);
    }

    public static CM_Vector3 CrossProduct(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        float x = (_v0.y * _v1.z) - (_v0.z * _v1.y);
        float y = (_v0.z * _v1.x) - (_v0.x * _v1.z);
        float z = (_v0.x * _v1.y) - (_v0.y * _v1.x);
        return new CM_Vector3(x, y, z);
    }

    public static CM_Vector3 Normalize(CM_Vector3 _v0)
    {
        double _magnitude = Magnitude(_v0);
        float _x = _v0.x / (float) _magnitude ;
        float _y = _v0.y / (float) _magnitude ;
        float _z = _v0.z / (float) _magnitude ;
        
        return new CM_Vector3(_x, _y, _z);
    }

    public static float Angle(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        float _temp = (float) (CM_Vector3.Magnitude(_v0) * CM_Vector3.Magnitude(_v1));
        _temp = (float) Math.Sqrt(_temp);

        return (float) Math.Acos(Dot(_v0, _v1) / _temp);
    }
    public static double Magnitude(CM_Vector3 _v0)
    {
        float _x = _v0.x;
        float _y = _v0.y;
        float _z = _v0.z;

        return Math.Sqrt(_x * _x + _y * _y + _z * _z);
    }
    public static float Dot(CM_Vector3 _v0, CM_Vector3 _v1)
    {
        float _x = _v0.x * _v1.x;
        float _y = _v0.y * _v1.y;
        float _z = _v0.z * _v1.z;
        
        return _x + _y + _z;
    }

    public float this[int _index]
    {
        get
        {
            switch (_index)
            {
                case 0:
                    return x;
                case 1:
                    return y;
                case 2:
                    return z;
                
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (_index)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                case 2:
                    z = value;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    
    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}", x, y, z);
    }
}