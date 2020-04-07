using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponIState 
{
    void OnStateEnter();
    void ChangePhysics();
    void ChangeState(WeaponIState newState);
    void HandleCollision(Collision col);
}
