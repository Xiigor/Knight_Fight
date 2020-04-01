using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerIState
{
    void UpdateState();
    void ToBasicState();
    void ToAttackState();
    void ToHitState();
    void ToDashState();
    void ToPickupState();
    void ToDeadState();
}
