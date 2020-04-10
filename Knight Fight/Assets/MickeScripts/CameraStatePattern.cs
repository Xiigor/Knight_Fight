using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatePattern : MonoBehaviour
{
    // **** STATE DECLARATIONS **** //
    private CameraAbstractClass currentState;

    [HideInInspector] public CameraArenaViewState arenaViewState;
    [HideInInspector] public CameraBattleViewState battleViewState;
    [HideInInspector] public CameraFollowPlayerState followPlayerState;

    // **** CAMERA MOVEMENT VARIABLES **** //
    [HideInInspector] public Vector3 velocity = Vector3.zero;   // Referenced to in SmoothDamp functions
    [HideInInspector] public float initialSmoothness = 3.0f;
    [HideInInspector] public float accelerationTimer = 0.0f;

    [Header("Camera Movement (values > 1 not recommended)")]

    public float zoomAcceleration = 0.25f;              // Higher value = slower zoom
    public float desiredSmoothness = 0.2f;      // Higher value = smoother camera

    // **** ARENA VIEW VARIABLES **** //
    [Header("Menu View")]

    public float cameraPositionX =  -5.0f;      // These are only suggested values
    public float cameraPositionY =  75.0f;      // Change as desired in Inspector
    public float cameraPositionZ = -30.0f;      // Goal is to give a full arena view

    // **** BATTLE VIEW VARIABLES **** //
    [Header("Battle View")]

    public string placeholder = "PLACEHOLDER";

    // **** FOLLOW PLAYER VARIABLES **** //     // NOT TO BE USED IN THE ACTUAL GAME CURRENTLY!!! Testing purposes only
    [Header("Follow Player")]

    public Transform playerObject;

    public float distFromPlayerY = 30.0f;       // By changing the distance from the player on the Y and Z axises,
    public float distFromPlayerZ = 10.0f;       // we avoid the camera planting itself straight inside the player

    void Awake()
    {
        arenaViewState = new CameraArenaViewState(this);
        battleViewState = new CameraBattleViewState(this);
        followPlayerState = new CameraFollowPlayerState(this);
    }

    void Start()
    {
        currentState = arenaViewState;
    }

    void LateUpdate()
    {
        currentState.Execute();

        DevStateChange();
    }

    public void ChangeState(CameraAbstractClass newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter();
    }

    private void DevStateChange()  // FUNCTION ONLY USED FOR TESTING, NOT TO BE IMPLEMENTED IN THE GAME
    {
        if(Input.GetKey("a"))
        {
            ChangeState(arenaViewState);
        }

        if(Input.GetKey("b"))
        {
            ChangeState(battleViewState);
        }

        if(Input.GetKey("f"))
        {
            ChangeState(followPlayerState);
        }
    }

    public void ZoomAcceleration()
    {
        if (initialSmoothness > desiredSmoothness)
        {
            for (float i = initialSmoothness; i > desiredSmoothness; i = i - 0.0005f)
            {
                accelerationTimer += Time.deltaTime;

                if (accelerationTimer > zoomAcceleration)
                {
                    initialSmoothness = initialSmoothness - 0.0005f;

                    accelerationTimer = 0;
                }
            }
        }
    }

    public void SmoothnessNormalizer()
    {
        if (initialSmoothness < desiredSmoothness)
        {
            initialSmoothness = desiredSmoothness;
        }
    }
}