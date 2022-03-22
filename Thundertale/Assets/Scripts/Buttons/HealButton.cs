using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : PlayerButton
{
    [SerializeField] float healValue = 0.2f;

    public override void Act()
    {
        base.Act();
        if(Health.Player != null)
            Health.Player.ChangeHealth(healValue);
    }
}
