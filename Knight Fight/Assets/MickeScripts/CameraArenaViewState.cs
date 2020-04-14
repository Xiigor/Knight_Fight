using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArenaViewState : CameraAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CameraArenaViewState(CameraStatePattern stateMachine)
    {
        base.p_camera = stateMachine;
    }

    public override void Enter()
    {
        p_camera.initialSmoothness = 3.0f;
        p_camera.accelerationTimer = 0.0f;
    }

    public override void Execute()
    {
        p_camera.ZoomAcceleration();

        MenuView();
    }

    public override void Exit()
    {

    }

    void MenuView()
    {
        Vector3 position = new Vector3();

        position.x = p_camera.cameraPositionX;
        position.y = p_camera.cameraPositionY;
        position.z = p_camera.cameraPositionZ;

        p_camera.transform.position = Vector3.SmoothDamp(p_camera.transform.position, position, ref p_camera.velocity, p_camera.initialSmoothness);
    }
}