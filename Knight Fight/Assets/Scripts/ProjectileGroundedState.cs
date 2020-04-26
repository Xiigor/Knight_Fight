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


    public void ChangeState(ProjectileIState newState)
    {
        throw new System.NotImplementedException();
    }

    public void OnStateEnter()
    {
        projectile.damage = 0;
        Physics.IgnoreLayerCollision(projectile.Player.layer, projectile.gameObject.layer, false);
        Debug.Log("Grounded");

    }

    public void UpdateState()
    {
        
    }
}
