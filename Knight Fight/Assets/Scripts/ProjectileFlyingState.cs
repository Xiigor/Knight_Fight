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

    //EJ FÄRDIG
    public void HandleCollision(Collision col)
    {
        if (col.gameObject.tag == projectile.playerTag)
        {
            if (col.gameObject == projectile.parentPlayer)
            {
                //Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), weapon.col);
            }
            //if (col.gameObject != weapon.parentPlayer)
            else
            {
                col.gameObject.GetComponent<PlayerStatePattern>().OnHit(projectile.damage);
              
            }
        }
        else
        {
            ChangeState(projectile.groundedState);
        }
        // Sätter hastigheten till 0 oavsett va den kolliderar med
        projectile.rb.velocity = new Vector3(0, 0, 0);
    }

    public void OnStateEnter()
    {
        LaunchFish();
        Debug.Log("FlyingState");
    }

    public void LaunchFish()
    {
        //Throw the weapon the way the player is facing 
        //Avnågon anledning funkade det inte med transform.forward då det va 90 grader fel så fick använda transform.right
        projectile.rb.velocity += projectile.Player.transform.right * projectile.ProjectileSpeed;
        
    }

}
