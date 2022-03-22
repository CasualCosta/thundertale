using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : PlayerButton
{
    [SerializeField] float damageValue = 1f;

    public override void Act()
    {
        base.Act();
        if(Health.Enemy != null)
            Health.Enemy.ChangeHealth(-damageValue);
    }
}
