using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGroundedState : ProjectileIState
{
    private readonly ProjectileBase projectile;
    public ProjectileGroundedState(ProjectileBase projectileBase)
    {
        projectile = projectileBase;
    }
    //public void ChangePhysics()
    //{
    //    throw new System.NotImplementedException();
    //}

    public void ChangeState(ProjectileIState newState)
    {
        throw new System.NotImplementedException();
    }

    public void HandleCollision(Collision col)
    {
        throw new System.NotImplementedException();
    }

    public void OnStateEnter()
    {
        projectile.damage = 0;
        Debug.Log("Grounded");

    }
}
