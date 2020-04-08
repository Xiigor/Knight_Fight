using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerState : CameraAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CameraFollowPlayerState(CameraStatePattern stateMachine)
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
        p_camera.SmoothnessNormalizer();

        FollowPlayer();
    }

    public override void Exit()
    {

    }

    void FollowPlayer()
    {
        Vector3 position = new Vector3();

        position.x = p_camera.playerObject.position.x;
        position.y = p_camera.playerObject.position.y + p_camera.distFromPlayerY;
        position.z = p_camera.playerObject.position.z - p_camera.distFromPlayerZ;

        p_camera.transform.position = Vector3.SmoothDamp(p_camera.transform.position, position, ref p_camera.velocity, p_camera.initialSmoothness);
    }
}