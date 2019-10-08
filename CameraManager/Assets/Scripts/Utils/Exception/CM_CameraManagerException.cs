using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_CameraManagerException : Exception
{
    protected string objectName;
    public override string Message => string.Format("Error {0} ", base.Message);

    public CM_CameraManagerException(string _objectName)
    {
        objectName = _objectName;
    }
}

public class CM_CameraManagerMissingComponentException : CM_CameraManagerException
{
    private CM_CameraComponent componentError;
    public CM_CameraManagerMissingComponentException(CM_CameraComponent _componentError, string _objName) : base(_objName)
    {
        componentError = _componentError;
    }

    public override string Message => $"\n OBJECT ID {componentError.ID} \n OBJECT {objectName} \n DETAILS {base.Message}";
}
public class CM_CameraManagerMissingCameraException : CM_CameraManagerException
{
    public CM_CameraManagerMissingCameraException(string _objName) : base(_objName)
    {
      
    }

    public override string Message => $"\n OBJECT {objectName} \n DETAILS {base.Message}";
}


