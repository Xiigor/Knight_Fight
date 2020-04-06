using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerIState
{
    void UpdateState();
    void ChangeState(PlayerIState newState);
    void TakeDamage(WeaponBase weapon);
}
