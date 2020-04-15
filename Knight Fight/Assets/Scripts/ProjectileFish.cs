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
        Player = GameObject.Find(playerTag);
        projectileTransform = gameObject.transform;  
    }

    private void Start()
    {
        currentState = flyingState;
        LaunchPos(Player);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity == new Vector3(0,0,0) && currentState == flyingState)
        {
            currentState = groundedState;
            currentState.OnStateEnter();
        }
    }

    public override void LaunchPos(GameObject parent)
    {
        //sätter projektilen på spelarens hand Kommer hit efter initsieringen av projektilen 
        projectileTransform.position = parent.transform.GetChild(1).position;
        currentState.OnStateEnter();
        //LaunchFish();
    }

    //public override void LaunchFish()
    //{
    //    //Throw the weapon the way the player is facing 
    //    //Avnågon anledning funkade det inte med transform.forward då det va 90 grader fel så fick använda transform.right
    //    rb.velocity += Player.transform.right * ProjectileSpeed;    
    //}
}
