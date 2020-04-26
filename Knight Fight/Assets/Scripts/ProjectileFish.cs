using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFish : ProjectileBase
{

    // Start is called before the first frame update
    private void Awake()
    {
        flyingState = new ProjectileFlyingState(this);
        groundedState = new ProjectileGroundedState(this);
        rb = GetComponent<Rigidbody>();
        parentObject = transform.parent.gameObject;
        Player = parentObject.GetComponent<WeaponThrowFishPattern>().parentPlayer.GetComponent<PlayerStatePattern>().rightHandGameobject;
        projectileTransform = gameObject.transform;  
    }

    private void Start()
    {
        currentState = flyingState;
        Physics.IgnoreLayerCollision(Player.layer, 15);
        LaunchPos(Player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    public override void LaunchPos(GameObject parent)
    {
        //sätter projektilen på spelarens hand Kommer hit efter initsieringen av projektilen 

        projectileTransform.position = Player.transform.position;
        projectileTransform.rotation = new Quaternion(0,0,0,0);
        currentState.OnStateEnter();
        //LaunchFish();
    }

    //public override void LaunchFish()
    //{
    //    rb.velocity += Player.transform.right * ProjectileSpeed;    
    //}
}
