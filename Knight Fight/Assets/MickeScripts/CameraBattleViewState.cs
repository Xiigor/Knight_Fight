using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBattleViewState : CameraAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CameraBattleViewState(CameraStatePattern stateMachine)
    {
        base.p_camera = stateMachine;
    }

    public override void Enter()
    {
        p_camera.initialSmoothness = 3.0f;
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}