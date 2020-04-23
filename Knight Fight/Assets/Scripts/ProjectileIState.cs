using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ProjectileIState
{
    void OnStateEnter();
    //void ChangePhysics();
    void ChangeState(ProjectileIState newState);
    //void HandleCollision(Collision col);
}
