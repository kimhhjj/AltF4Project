using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/HealEffect")]
public class HealItem : ItemEffect
{
    public int healAmount;

    public override void Apply(GameObject target)
    {
        Debug.Log($"Heal : {healAmount} 증가" );
    }
}
