using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFlyingState : ProjectileIState
{
    private readonly ProjectileBase projectile;

    public ProjectileFlyingState(ProjectileBase projectileBase)
    {
        projectile = projectileBase;
    }
    //public void ChangePhysics()
    //{
    //    throw new System.NotImplementedException();
    //}

    public void ChangeState(ProjectileIState newState)
    {
        if (newState == projectile.groundedState)
        {
            projectile.currentState = newState;
        }
    }


    public void OnStateEnter()
    {
        LaunchFish();
        Debug.Log("FlyingState");
    }

    public void LaunchFish()
    {
        projectile.rb.velocity += projectile.Player.transform.forward * projectile.ProjectileSpeed;   
    }

}
