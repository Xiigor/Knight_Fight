using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponStateMachine : MonoBehaviour
{
    protected WeaponStates State;

    public void SetState(WeaponStates weaponStates)
    {
        State = weaponStates;
        StartCoroutine(State.Unequipped());
    }
}
