using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponStates : MonoBehaviour
{
    public virtual IEnumerator Throw()
    {
         yield break; 
    }

    public virtual IEnumerator Unequipped()
    {
        yield break;
    }

    public virtual IEnumerator Equipped()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }

}
