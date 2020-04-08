using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraAbstractClass
{
    [HideInInspector] public bool _IsInitialized;

    protected CameraStatePattern p_camera;

    public virtual void Enter()
    {

    }

    public virtual void Execute()
    {

    }

    public virtual void Exit()
    {

    }
}